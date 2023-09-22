using Microsoft.Extensions.Logging;
using SelfieAWookie.API.UI.Controllers;
using SelfieAWookie.API.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.SelfieAWookie.API.UI
{
    public class ErrorsControllerUnitTest
    {
        [Fact]
        public void ShouldReturnError404()
        {
            ErrorsController controller = new();

            var erreur = controller.Error404();

            Assert.NotNull(erreur);
            Assert.True(erreur.ErrorCode == 404);
            Assert.True(erreur.GetType() == typeof(Error));

        }
    }
}
