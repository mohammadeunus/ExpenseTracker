using ExpenseTracker.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using FluentAssertions;

namespace TestExpenseTracker;

public class UnitTestCategoriesController
{ 
    /*
    [Fact]
    public async void AddCategory_ReturnsOkResult()
    {
        // Arrange
        var mockRepository = new Mock<ICategoriesRepository>();
        mockRepository.Setup(repo => repo.AddCategoryAsync(It.IsAny<string>()))
            .ReturnsAsync(true);

        var controller = new CategoriesController(mockRepository.Object);

        // Act
        var result = await controller.AddCategory("TestCategory");

        // Assert
        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().Be("Category added successfully.");
    }

    [Fact]
    public async void AddCategory_ReturnsBadRequestResult_WhenNoDataInserted()
    {
        // Arrange
        var mockRepository = new Mock<ICategoriesRepository>();
        var controller = new CategoriesController(mockRepository.Object);

        // Act
        var result = await controller.AddCategory(null);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>()
            .Which.Value.Should().Be("No data inserted.");
    }*/
}