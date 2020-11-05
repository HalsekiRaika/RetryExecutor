# RetryExecutor
Simply CSharp Library. Retry on a method execution that may fail.

# Usage
```cs
 HttpClient client = new HttpClient();
 Uri url = new Uri("http://example.com/index.json");

 string value = 
   ReSpell.Execute(5, 5, // RetryRemaining, RetryInterval
     () => { client.GetStringAsync(url).Result } // Action or TResult
     (count) => { Console.WriteLine($"Retry ({count})"); } // RemainAction [Action<int>: int passes the current number of retries.]
     (count) => { Console.WriteLine("Failure"); } // FailureAction (If it fails, just throw it.) [Action<int>: Same as RemainAction.]
   );
```
