using System;
using Koans.Lessons;
using Koans.Utils;
using Xunit;
using CurrentLesson = Koans.Lessons.Lesson7AsyncInvoke;

namespace Koans.Tests
{

    public class Lesson7AsyncInvokeTest
    {
        [Fact]
        public void TestAllQuestions()
        {
            Action<Lesson7AsyncInvoke> action = l => { l.____ = "C"; l._____ = "A"; l.______ = "B"; };
            KoanUtils.AssertLesson<Lesson7AsyncInvoke>(l => l.TheBloodyHardAsyncInvokationPatter(), action);
            //KoanUtils.Verify<CurrentLesson>(l => l.NiceAndEasyFromAsyncPattern(), 48);
            // Note: I don't know how to properly test AsynchronousRuntimeIsNotSummed
            KoanUtils.Verify<CurrentLesson>(l => l.TimeoutMeansStopListeningDoesNotMeanAbort(), "Give me 5, Joe");
            KoanUtils.Verify<CurrentLesson>(l => l.AsynchronousObjectsAreProperlyDisposed(), "D");
        }
    }
}