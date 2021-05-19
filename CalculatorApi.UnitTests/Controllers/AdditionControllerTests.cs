using CalculatorApi.Controllers;
using CalculatorApi.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CalculatorApi.UnitTests.TheoryProviders;
using Xunit;

namespace CalculatorApi.UnitTests.Controllers
{

    public class AdditionControllerTests
    {
        private readonly AdditionController _controller;

        public AdditionControllerTests()
        {
            _controller = new AdditionController();
        }

        [Fact]
        public void Post_Should_Return_Bad_Request_For_No_Input()
        {
            // Arrange
            MultiInputModel input = null;

            // Act
            var result = _controller.Post(input);

            // Assert
            result.Should()
                .NotBeNull();

            result.Should()
                .BeOfType<BadRequestResult>();
        }

        [Fact]
        public void Post_Should_Return_Bad_Request_For_No_Numeric_Input()
        {
            // Arrange
            var input = new MultiInputModel();

            // Act
            var result = _controller.Post(input);

            // Assert
            result.Should()
                .NotBeNull();

            result.Should()
                .BeOfType<BadRequestResult>();
        }

        [Fact]
        public void Post_Should_Return_Value_For_Single_Value_Input()
        {
            // Arrange
            var numericInput = 1;
            var input = new MultiInputModel();
            input.Inputs.Add(numericInput);

            // Act
            var result = _controller.Post(input);

            // Assert
            result.Should()
                .NotBeNull();

            result.Should()
                .BeOfType<OkObjectResult>();

            var okObjectResult = result as OkObjectResult;

            var model = okObjectResult.Value;

            model.Should()
                .BeOfType<ResultModel>();

            var resultModel = model as ResultModel;

            resultModel.Result
                .Should()
                .Be(numericInput);
        }

        [Theory]
        [ClassData(typeof(MultiNumericInputProvider))]
        public void Post_Should_Return_Correct_Value_For_Multiple_Inputs(MultiInputModel input)
        {
            // Arrange
            var expected = input.Inputs.Sum(_ => _);
            
            // Act
            var result = _controller.Post(input);

            // Assert
            result.Should()
                .NotBeNull();

            result.Should()
                .BeOfType<OkObjectResult>();

            var okObjectResult = result as OkObjectResult;

            var model = okObjectResult.Value;

            model.Should()
                .BeOfType<ResultModel>();

            var resultModel = model as ResultModel;

            resultModel.Result
                .Should()
                .Be(expected);

        }
    }
}
