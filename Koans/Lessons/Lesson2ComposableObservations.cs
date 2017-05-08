using System.Collections.Generic;
using System.Reactive.Linq;
using Koans.Utils;

using System;
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
    public class Lesson2ComposableObservations
    {
        public int ___ = 100;
        public object ____ = "Please Fill in the blank";

        [Fact]
        public void ComposableAddition()
        {
            var received = 0;
            var numbers = new[] { 10, 100, ___ };
            numbers.ToObservable().Sum().Subscribe(x => received = x);
            Assert.Equal(1110, received);
        }

        [Fact]
        public void ComposableBeforeAndAfter()
        {
            var names = Range.Create(1, 6);
            var a = "";
            var b = "";

            names.ToObservable().Do(n => a += n).Where(n => n.IsEven()).Do(n => b += n).Subscribe();
            Assert.Equal(____, a);
            Assert.Equal("246", b);

        }

        [Fact]
        public void WeWroteThis()
        {
            var received = new List<string>();
            var names = new[] { "Bart", "Marge", "Wes", "Linus", "Erik" };
            names.ToObservable().Where(n => n.Length <= ___).Subscribe(x => received.Add(x));
            Assert.Equal("[Bart, Wes, Erik]", received.AsString());
        }

        [Fact]
        public void ConvertingEvents()
        {
            var received = "";
            var names = new[] { "wE", "hOpE", "yOU", "aRe", "eNJoyIng", "tHiS" };
            names.ToObservable().Select(x => x.___()).Subscribe(x => received += x + " ");
            Assert.Equal("we hope you are enjoying this ", received);
        }

        [Fact]
        public void CreatingAMoreRelevantEventStream()
        {
            var received = "";
            var mouseXMovements = new[] { 100, 200, 150 };
            var relativemouse = mouseXMovements.ToObservable().Select((int x) => x - ___);
            relativemouse.Subscribe(x => received += x + ", ");
            Assert.Equal("50, 150, 100, ", received);
        }

        [Fact]
        public void CheckingEverything()
        {
            bool? received = null;
            var names = new[] { 2, 4, 6, 8 };
            names.ToObservable().All(x => x.IsEven()).Subscribe(x => received = x);
            Assert.Equal(____, received);
        }

        [Fact]
        public void CompositionMeansTheSumIsGreaterThanTheParts()
        {
            var numbers = Observable.Range(1, 10);
            numbers.Where(x => x > ___).Sum().Subscribe(x => Assert.Equal(19, x));
        }
    }
}