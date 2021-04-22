using Fiction.Controllers;
using Fiction.Models;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace FictionTests
{
    public class CharactersControllerTests
    {
        [Fact]
        public void Get_Success_DependencyCalledOnce()
        {
            //Arrange
            Mock<ICharactersRepository> charactersRepository = new Mock<ICharactersRepository>();
            charactersRepository.Setup(x => x.GetAll()).Returns(new List<Character> { new Character { } });

            CharactersController sut = new CharactersController(charactersRepository.Object);

            //Act
            sut.Get(0);

            //Assert
            charactersRepository.Verify(x => x.GetAll(), Times.Once);
        }
    }
}