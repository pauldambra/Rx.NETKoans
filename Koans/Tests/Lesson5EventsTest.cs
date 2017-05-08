using Koans.Utils;
using Xunit;
using CurrentLesson = Koans.Lessons.Lesson5Events;

namespace Koans.Tests
{

    public class Lesson5EventsTest
    {
        [Fact]
        public void TestAllQuestions()
        {
            KoanUtils.Verify<CurrentLesson>(l => l.TheMainEvent(), "BAR");
        }
    }
}