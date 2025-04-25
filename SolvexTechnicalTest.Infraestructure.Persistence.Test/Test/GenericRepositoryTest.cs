using Microsoft.EntityFrameworkCore;
using Moq;
using SolvexTechnicalTest.Core.Domain.Common;
using SolvexTechnicalTest.Infraestructure.Persistence.Base;
using SolvexTechnicalTest.Infraestructure.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

public class GenericRepositoryTests
{
    private readonly Mock<ApplicationContext> _mockContext;
    private readonly Mock<DbSet<TestEntity>> _mockDbSet;
    private readonly GenericRepository<TestEntity> _repository;

    public GenericRepositoryTests()
    {
        _mockContext = new Mock<ApplicationContext>(new DbContextOptions<ApplicationContext>());
        _mockDbSet = new Mock<DbSet<TestEntity>>();
        _mockContext.Setup(c => c.Set<TestEntity>()).Returns(_mockDbSet.Object);
        _repository = new GenericRepository<TestEntity>(_mockContext.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddEntityAndSaveChanges()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };

        // Act
        var result = await _repository.CreateAsync(entity);

        // Assert
        _mockDbSet.Verify(db => db.Add(entity), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        Assert.Equal(entity.Id, result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveEntityAndSaveChanges()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };

        // Act
        await _repository.DeleteAsync(entity);

        // Assert
        _mockDbSet.Verify(db => db.Remove(entity), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }

    [Fact]
    public async Task ExistsAsync_ShouldReturnTrueIfEntityExists()
    {
        // Arrange
        var id = 1;
        _mockDbSet.Setup(db => db.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<TestEntity, bool>>>(), default))
                  .ReturnsAsync(true);

        // Act
        var result = await _repository.ExistsAsync(id);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllEntities()
    {
        // Arrange
        var data = new List<TestEntity>
        {
            new TestEntity { Id = 1 },
            new TestEntity { Id = 2 }
        }.AsQueryable();

        _mockDbSet.As<IQueryable<TestEntity>>().Setup(m => m.Provider).Returns(data.Provider);
        _mockDbSet.As<IQueryable<TestEntity>>().Setup(m => m.Expression).Returns(data.Expression);
        _mockDbSet.As<IQueryable<TestEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
        _mockDbSet.As<IQueryable<TestEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnEntityIfExists()
    {
        // Arrange
        var id = 1;
        var entity = new TestEntity { Id = id };
        _mockDbSet.Setup(db => db.FindAsync(id)).ReturnsAsync(entity);

        // Act
        var result = await _repository.GetByIdAsync(id);

        // Assert
        Assert.Equal(entity, result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateEntityAndSaveChanges()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };

        // Act
        await _repository.UpdateAsync(entity);

        // Assert
        _mockDbSet.Verify(db => db.Update(entity), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }

    // Helper class for testing
    public class TestEntity : AuditableEntity
    {
        public int Id { get; set; }
    }
}
