
using Domain;
using Domain.Commands;
using Domain.DTO;
using Domain.Query;
using Moq;
using Service;
using System.Data;

namespace TestDomain;

public class UnitTest1
{
    [Fact]
    public void SuccessSearchById()
    {
        //ARRAGE
        SearchById search = new SearchById();
        int id = 100;
        string login = "test";
        string password = "test";
        string country = "test";
        var mock = new Mock<IRepository>();
        mock.Setup(row => row.GetById(It.IsAny<int>()))
            .Returns(new UserDTO { Id = id, Login = login, Password = password, Country = country});
        IQueryService<SearchById, UserDTO> query = new GetUserByIdQuery(mock.Object);

        //ACT
        var item = query.Execute(search);
        //ASSERT
        Assert.NotNull(item);
        Assert.Equal(login, item.Login);
        Assert.Equal(password, item.Password);
        Assert.Equal(country, item.Country);
        Assert.Equal(id, item.Id);
        mock.Verify(row => row.GetById(It.IsAny<int>()), Times.Once());
    }
    [Fact]
    public void ReturnNullInSearchById()
    {
        //ARRAGE
        SearchById search = new SearchById();
        search.Id = 1;
        var mock = new Mock<IRepository>();
        mock.Setup(row => row.GetById(It.IsAny<int>()));
        IQueryService<SearchById, UserDTO> query = new GetUserByIdQuery(mock.Object);
        //ACT
        var item = query.Execute(search);
        //ASSERT
        Assert.NotNull(item);
        mock.Verify(row => row.GetById(It.IsAny<int>()), Times.Once());
    }
    [Fact]
    public void SearchByZeroId()
    {
        //ARRAGE
        SearchById search = new SearchById();
        int id = 0;
        string login = "test";
        string password = "test";
        string country = "test";
        var mock = new Mock<IRepository>();
        mock.Setup(row => row.GetById(It.IsAny<int>()))
            .Returns(
                        new UserDTO { 
                            Id = id, 
                            Login = login, 
                            Password = password, 
                            Country = country 
                        });
        IQueryService<SearchById, UserDTO> query = new GetUserByIdQuery(mock.Object);

        //ACT
        var item = query.Execute(search);
        //ASSERT
        Assert.Null(item);
        mock.Verify(row => row.GetById(It.IsAny<int>()), Times.Never());
    }
}