# Unity Async Behaviours

Unity has two async worlds:

1. Unity Player Loop–driven async → **Coroutines**
2. .NET / OS thread–driven async → **Tasks / async-await**

## Coroutines

A Unity native method that can suspend execution and resume at a later time.

In Unity applications, this means coroutines can start running in one frame and then resume in another, allowing you to spread tasks across several frames.

Notes:

- Not threads, not async I/O
- Executed only on main thread
- Driven by Unity’s PlayerLoop
- **Runs immediately until first yield.**
- Very lightweight.
- Now, since it runs as part of Unity life cycle:
  - No race condition.
  - No lock or deadlocks.
  - No race conditions as they are run as part of Unity life cycle.
  - Look at [unity life cycle](https://docs.unity3d.com/6000.3/Documentation/Manual/execution-order.html) for details as to when it resumes back.
  - If you look there are mainly 3 points of resume:
    1. ... -> FixedUpdate() -> OnTriggerXXX() -> OnCollisionXXX() -> **yield return WaitForFixedUpdate()** -> On MouseXXX() -> Update()
    2. Update() ->
       - yield return null;
       - yield WaitForSeconds
       - yield WWW
       - yield StartCoroutine() // this inner coroutines start immediately, but we wait for it to complete here.
       - -> LateUpdate()
    3. OnPostRender() -> **yield waitForEndOfFrame()** -> ....
- Stored per MonoBehaviour
- Auto stops when GameObject destroyed OR disabled.
- NOTE: Disabling the script component by setting `enabled = false` doesn’t stop coroutines.

### When Coroutines Are the Right Tool

- ✅ Frame-by-frame logic
- ✅ Animation sequencing
- ✅ Gameplay timing
- ✅ Unity API access
- ❌ CPU-heavy work
- ❌ Real async I/O (file, network)

## <br/>

## Tasks / async-await

- Represent work that may run asynchronously
- Often use ThreadPool threads
- May run in parallel, but not guaranteed.
- Expensive.
- It doesn't start immediately, but is scheduled. The ThreadPool may start it immediately, but not guaranteed.

### Ways to start:

1. `Task.Run( () => {} )` // most preferred.
2. `Task t = new Task( () => {} ); t.Start();`
3. `Task task = Task.Factory.StartNew( () => {} );` // usually old way

## Where coroutines are better than tasks

1. When relying on monoBehaviour's life.
1. When frame based calculations needed.
1. It can easily work with unity API.
1. It guarantees main thread execution.
1. Usually when writing gameplay logic / animations.
1. They're lightweight, and thus millions can run without much problem.

## Where Tasks are better than coroutines

1. Where Unity's API is not needed. Example = CI/CD pipeline, headless mode.
1. CPU heavy work. Coroutines do constant polling, it doesn't.
1. May run in multiple cores. And thus improves performance. Also, it doesn't impact the FPS of the game.
1. Good for File IO, network calls, Database access, Cloud API, etc.
1. Better error handling, and can propagate error using try-catch.
1. Easy (and detached) cancellation logic.
1. Returns result. Chainable. And Testable.

## Hybrid = Use Tasks inside coroutines.

```cs
IEnumerator DO(()=>{
   Task<int> task = Task.Run(() =>
    {
        return 100;
    });

    yield return new WaitUntil(()=> task.IsCompleted);
   // OR
   //  while (!task.IsCompleted)
   //      yield return null;

   if(task.IsFaulted)
      Debug.Log($"Error")

   int result = task.Result;
});

```

## Hybrid = Use UnityWebRequest inside Tasks. Not recommended.

```cs
async Task<int> DO(){
   using UnityWebRequest www = UnityWebRequest.Get(filePath);
   var operation = www.SendWebRequest();

   while (!operation.isDone)
      await Task.Yield();

   if (www.result != UnityWebRequest.Result.Success)
      throw new Exception("Error");

   string text = www.downloadHandler.text;
}
```

### Hybrid = Use Coroutines inside tasks

- The task might not run on the main thread. So, we cannot directly start coroutine from inside (not guaranteed).
- So just use a main thread dispatcher, and start coroutine from there.
