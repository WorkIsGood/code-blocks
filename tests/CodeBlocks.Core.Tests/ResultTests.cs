using CodeBlocks.Core.Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodeBlocks.Core.Tests
{
    public class ResultTests
    {
        [Fact]
        public void Result_Empty_Ctor_Success()
        {
            IResult result = new Result();
            Assert.True(result.Success);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Result_Ctor_Success(bool success)
        {
            IResult result = new Result(success);
            Assert.Equal(success, result.Success);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Result_Has_Error_Messages(int errorCount)
        {
            var result = new Result(false, GetErrorMessages(errorCount).ToList());

            Assert.NotNull(result.ErrorsMessages);
            Assert.Equal(errorCount, result.ErrorsMessages.Count);
            Assert.Equal(GetErrorMessageContent(1), result.ErrorsMessages.FirstOrDefault()?.Content);
        }


        public static IEnumerable<ResultMessage> GetErrorMessages(int messageCount)
        {
            var messages = new List<ResultMessage>
            {
                new ResultMessage { Content = GetErrorMessageContent(1), Type = ResultMessageType.Error },
                new ResultMessage { Content = GetErrorMessageContent(2), Type = ResultMessageType.Error },
                new ResultMessage { Content = GetErrorMessageContent(3), Type = ResultMessageType.Error },
                new ResultMessage { Content = GetErrorMessageContent(4), Type = ResultMessageType.Error }
            };

            return messages.Take(messageCount);
        }

        public static string GetErrorMessageContent(int errorNumber)
        {
            return $"err_{errorNumber}";
        }
    }
}
