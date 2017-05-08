using System.Drawing;
using Koans.Utils;
using Xunit;
using CurrentLesson = Koans.Lessons.Lesson3Linq;

namespace Koans.Tests
{

    public class Lesson3LinqTest
    {
        [Fact]
        public void TestAllQuestions()
        {
            KoanUtils.Verify<CurrentLesson>(l => l.Linq(), 11);
            KoanUtils.Verify<CurrentLesson>(l => l.LinqOverMouseEvents(), new Point(75, 75));
        }
    }
}