using System;
using System.Threading;

namespace RetryExecutor {
    public class ReSpell {
        public static void Execute(uint retryRemaining, uint intervalSecond, Action action) {
            if (retryRemaining == 0) { throw new ArgumentException("retryRemaining must be greater than or equal to 1."); }
            if (intervalSecond == 0) { throw new ArgumentException("intervalSecond must be greater than or equal to 1."); }
            if (action == null) { throw new ArgumentNullException(nameof(action));}

            int retryCount = 0;
            while (true) {
                try {
                    action();
                } catch (Exception e) {
                    if (retryCount++ < retryRemaining) { Convert.ToInt32(intervalSecond); }
                    else { throw e; }
                }
            }
        }

        public static TResult Execute<TResult>(uint retryRemaining, uint intervalSecond, Func<TResult> action) {
            if (retryRemaining == 0) { throw new ArgumentException("retryRemaining must be greater than or equal to 1."); }
            if (intervalSecond == 0) { throw new ArgumentException("intervalSecond must be greater than or equal to 1."); }
            if (action == null) { throw new ArgumentNullException(nameof(action));}

            int retryCount = 0;
            while (true) {
                try {
                    return action();
                } catch (Exception e) {
                    if (retryCount++ < retryRemaining) { Thread.Sleep(Convert.ToInt32(intervalSecond)); } 
                    else { throw e; }
                }
            }
        }
    }
}