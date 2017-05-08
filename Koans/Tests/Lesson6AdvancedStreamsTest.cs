using System;
using Koans.Utils;
using Xunit;
using CurrentLesson = Koans.Lessons.Lesson6AdvancedStreams;

namespace Koans.Tests
{

    public class Lesson6AdvancedStreamsTest
    {
        [Fact]
        public void TestAllQuestions()
        {
            KoanUtils.Verify<CurrentLesson>(l => l.Merging(), "1 A 2 B 3 C ");
            KoanUtils.Verify<CurrentLesson>(l => l.SplittingUp(), 2);
            KoanUtils.Verify<CurrentLesson>(l => l.MergingEvents(), "I am perfect.");
            KoanUtils.AssertLesson<CurrentLesson>(l => l.NeedToSubscribeImediatelyWhenSplitting(),
                                                  l =>
                                                  StringUtils.call =
                                                  (s, p) =>
                                                  ObservableExtensions.Subscribe((IObservable<double>)s, (Action<double>)p[0]));
            KoanUtils.Verify<CurrentLesson>(l => l.MultipleSubscriptions(), 2.0);
        }
    }
}