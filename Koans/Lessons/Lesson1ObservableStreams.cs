using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Koans.Utils;
using Xunit;


namespace Koans.Lessons
{
    /*
     * How to Run: Press Ctrl+R,T (go ahead, try it now)
     * Step 1: find the 1st method that fails
     * Step 2: Fill in the blank ____ to make it pass
     * Step 3: run it again
     * Note: Do not change anything other than the blank
     */
    public class Lesson1ObservableStreams
    {
        public object ___ = "Please Fill in the blank";
        public int ____ = 100;

        [Fact]
        public void SimpleSubscription()
        {
            Observable.Return(42).Subscribe(x => Assert.Equal(___, x));
        }

        [Fact]
        public void WhatGoesInComesOut()
        {
            Observable.Return(___).Subscribe(x => Assert.Equal(101, x));
        }

        //Q: Which interface Rx apply? (hint: what does "Return()" return)

        //A:

        [Fact]
        public void ThisIsTheSameAsAnEventStream()
        {
            var events = new Subject<int>();
            events.Subscribe(x => Assert.Equal(___, x));
            events.OnNext(37);
        }

        //Q: What is the relationship between "ThisIsTheSameAsAnEventStream()" and "SimpleSubscription()"?

        //A:

        [Fact]
        public void HowEventStreamsRelateToObservables()
        {
            var observableResult = 1;
            Observable.Return(73).Subscribe(i => observableResult = i);
            var eventStreamResult = 1;
            var events = new Subject<int>();
            events.Subscribe(i => eventStreamResult = i);
            events.___(73);
            Assert.Equal(observableResult, eventStreamResult);
        }

        //Q: What does Observable.Return() map to for a Subject?

        //A:


        [Fact]
        public void EventStreamsHaveMultipleEvents()
        {
            var eventStreamResult = 0;
            var events = new Subject<int>();
            events.Subscribe(i => eventStreamResult += i);
            events.OnNext(10);
            events.OnNext(7);
            Assert.Equal(____, eventStreamResult);
        }

        //Q: What does Observable.Return() map to for a Subject?

        //A:


        [Fact]
        public void SimpleReturn()
        {
            var received = "";
            Observable.Return("Foo").Subscribe((string s) => received = s);
            Assert.Equal(___, received);
        }

        [Fact]
        public void TheLastEvent()
        {
            var received = "";
            var names = new[] { "Foo", "Bar" };
            names.ToObservable().Subscribe((s) => received = s);
            Assert.Equal(___, received);
        }

        [Fact]
        public void EveryThingCounts()
        {
            var received = 0;
            var numbers = new[] { 3, 4 };
            numbers.ToObservable().Subscribe((int x) => received += x);
            Assert.Equal(___, received);
        }

        [Fact]
        public void ThisIsStillAnEventStream()
        {
            var received = 0;
            var numbers = new Subject<int>();
            numbers.Subscribe((int x) => received += x);
            numbers.OnNext(10);
            numbers.OnNext(5);
            Assert.Equal(___, received);
        }

        [Fact]
        public void AllEventsWillBeRecieved()
        {
            var received = "Working ";
            var numbers = Range.Create(9, 5);
            numbers.ToObservable().Subscribe((int x) => received += x);
            Assert.Equal(___, received);
        }

        [Fact]
        public void DoingInTheMiddle()
        {
            var status = new List<string>();
            var daysTillTest = Range.Create(4, 1).ToObservable();
            daysTillTest.Do(d => status.Add(d + "=" + (d == 1 ? "Study Like Mad" : ___))).Subscribe();
            Assert.Equal("[4=Party, 3=Party, 2=Party, 1=Study Like Mad]", status.AsString());
        }

        [Fact]
        public void NothingListensUntilYouSubscribe()
        {
            var sum = 0;
            var numbers = Range.Create(1, 10).ToObservable();
            var observable = numbers.Do(n => sum += n);
            Assert.Equal(0, sum);
            observable.___();
            Assert.Equal(1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10, sum);
        }

        [Fact]
        public void EventsBeforeYouSubscribedDoNotCount()
        {
            var sum = 0;
            var numbers = new Subject<int>();
            var observable = numbers.Do(n => sum += n);
            numbers.OnNext(1);
            numbers.OnNext(2);
            observable.Subscribe();
            numbers.OnNext(3);
            numbers.OnNext(4);
            Assert.Equal(___, sum);
        }

        [Fact]
        public void EventsAfterYouUnsubscribDoNotCount()
        {
            var sum = 0;
            var numbers = new Subject<int>();
            var observable = numbers.Do(n => sum += n);
            var subscription = observable.Subscribe();
            numbers.OnNext(1);
            numbers.OnNext(2);
            subscription.Dispose();
            numbers.OnNext(3);
            numbers.OnNext(4);
            Assert.Equal(___, sum);
        }

        [Fact]
        public void EventsWhileSubscribing()
        {
            var recieved = new List<string>();
            var words = new Subject<string>();
            var observable = words.Do(recieved.Add);
            words.OnNext("Peter");
            words.OnNext("said");
            var subscription = observable.Subscribe();
            words.OnNext("you");
            words.OnNext("look");
            words.OnNext("pretty");
            subscription.Dispose();
            words.OnNext("ugly");
            Assert.Equal(___, string.Join(" ", recieved));
        }

        [Fact]
        public void UnsubscribeAtAnyTime()
        {
            var received = "";
            var numbers = Range.Create(1, 9);
            IDisposable un = null;
            un = numbers.ToObservable(NewThreadScheduler.Default).Subscribe((int x) =>
                                                                                {
                                                                                    received += x;
                                                                                    if (x == 5)
                                                                                    {
                                                                                        un.___();
                                                                                    }
                                                                                });
            Thread.Sleep(100);
            Assert.Equal("12345", received);
        }

        [Fact]
        public void TakeUntilFull()
        {
            var received = "";
            var subject = new Subject<int>();
            subject.TakeUntil(subject.Where(x => x > ____)).Subscribe(x => received += x);
            subject.OnNext(Range.Create(1, 9).ToArray());
            Assert.Equal("12345", received);
        }
    }
}