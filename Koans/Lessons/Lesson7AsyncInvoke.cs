using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Koans.Utils;
using Xunit;


namespace Koans.Lessons
{

    public class Lesson7AsyncInvoke
    {
        public const int __ = 1000;
        public int ___ = 0;
        public string ____ = "Please Fill in the blank";
        public object _____ = "Please Fill in the blank";
        public object ______ = "Please Fill in the blank";

        [Fact]
        public void TheBloodyHardAsyncInvokationPatter()
        {
            // You need to fill in the 3 ___'s with A,B & C in the order they will execute
            var called = "";
            var sub = new Subject<double>();
            Func<int, double> halve = x =>
                                          {
                                              called += _____;
                                              return x * 0.5;
                                          };
            double? result = 0;
            sub.Subscribe(n =>
                              {
                                  called += ____;
                                  result = n;
                              });
            halve.BeginInvoke(101, iar =>
                                       {
                                           called += ______;
                                           sub.OnNext(halve.EndInvoke(iar));
                                           sub.OnCompleted();
                                       }, null);
            ThreadUtils.WaitUntil(() => result != 0);
            Assert.Equal(50.5, result);
            Assert.Equal("ABC", called);
        }

        //[Fact]
        //public void NiceAndEasyFromAsyncPattern()
        //{
        //	Func<int, double> halve = x => x*0.5;
        //	double result = 0;
        //	var asyncInvoker = Observable.FromAsyncPattern<int, double>(halve.BeginInvoke,
        //	                                                            halve.EndInvoke);
        //	asyncInvoker(___).SubscribeOn(Scheduler.Immediate).Run(n => result = n);
        //	Assert.Equal(24, result);
        //}

        //[Fact]
        //public void AsynchronousRunInParallel()
        //{
        //	Func<int, int> inc = (int x) =>
        //	                     	{
        //	                     		Thread.Sleep(1500);
        //	                     		return x + 1;
        //	                     	};
        //	double result = 0;
        //	var incAsync = Observable.FromAsyncPattern<int, int>(inc.BeginInvoke,
        //	                                                     inc.EndInvoke);
        //	incAsync(1).Merge(incAsync(9)).Sum().SubscribeOn(Scheduler.Immediate).Subscribe(n => result = n);
        //	Assert.Equal(12, result);
        //}


        [Fact]
        public void AsyncLongRunningTimeout()
        {
            Func<int, string> highFive = x =>
                                             {
                                                 Thread.Sleep(1500);
                                                 return "Give me " + x;
                                             };
            string result = null;
            var incAsync = highFive.ToAsync();
            var timeout = TimeSpan.FromMilliseconds(500);
            incAsync(5).Timeout(timeout, Observable.Return("Too Slow Joe")).SubscribeOn(Scheduler.Immediate).Subscribe(n => result = n);
            Assert.Equal(____, result);
        }

        [Fact]
        public void TimeoutMeansStopListeningDoesNotMeanAbort()
        {
            string result = null;
            string returned = null;
            Func<string, string> highFive = n =>
                                                {
                                                    Thread.Sleep(900);
                                                    result = "Give me 5, " + n;
                                                    return result;
                                                };
            var async = highFive.ToAsync();
            var timeout = TimeSpan.FromMilliseconds(500);
            async("Joe").Timeout(timeout, Observable.Return("Too Slow Joe")).SubscribeOn(Scheduler.Immediate).Subscribe(s => returned = s);
            ThreadUtils.WaitUntil(() => result != null);
            Assert.Equal("Too Slow Joe", returned);
            Assert.Equal(result, ____);
        }

        [Fact]
        public void AsynchronousObjectsAreProperlyDisposed()
        {
            Func<int, string> highFive = x =>
                                             {
                                                 Thread.Sleep(x * 100);
                                                 return "" + x;
                                             };
            string disposed = null;
            var incAsync = highFive.ToAsync();
//            var timeout = TimeSpan.FromMilliseconds(500);
            Func<int, IObservable<string>> launch = (int i) => incAsync(i).Finally(() => disposed += ____ + i + ",");
            var all = launch(1).Merge(launch(2)).Merge(launch(3)).Merge(launch(4)).Merge(launch(5));

            all.Run();

            Assert.Equal("D1,D2,D3,D4,D5,", disposed);
        }
    }
}