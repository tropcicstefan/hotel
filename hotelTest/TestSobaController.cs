using AutoMapper;
using hotel.Controllers.ApiControllers;
using hotel.DTO;
using hotel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace hotelTest
{
    [TestClass]
    public class TestSobaController
    {
        private TestSobaDbSet GetDemoSoba = new TestSobaDbSet {
                new Soba { ID = 1, SobaTipID = 1, HotelID = 1 },
                new Soba { ID = 2, SobaTipID = 2, HotelID = 2 },
                new Soba { ID = 3, SobaTipID = 1, HotelID = 1 }
        };

        public TestSobaController()
        {
            TestProfile.Run();
        }

        [TestMethod]
        public void GetSobaVracaSveSobe()
        {
            
            var context = new TestHotelContext();
            context.Sobas = GetDemoSoba;

            var controller = new SobaController(context);
            var result = controller.GetSobas();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            TestProfile.De();
        }

        [TestMethod]
        public void GetSobaVracaSpecificnuSobu()
        {
            
            var context = new TestHotelContext();
            context.Sobas = GetDemoSoba;

            var controller = new SobaController(context);
            IHttpActionResult actionResult = controller.GetSoba(3);


            var contentResult = actionResult as OkNegotiatedContentResult<SobaDto>;

            
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.ID);
            TestProfile.De();
        }

        [TestMethod]
        public void GetSobaVracaNotFound()
        {

            var context = new TestHotelContext();
            context.Sobas = GetDemoSoba;

            var controller = new SobaController(context);
            IHttpActionResult result = controller.GetSoba(99);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            TestProfile.De();
        }

        [TestMethod]
        public void PostSobaVracaTuSobu()
        {
            var controller = new SobaController(new TestHotelContext());

            SobaDto soba = new SobaDto { ID = 4, SobaTipID = 1, HotelID = 1 };

            var result =
                controller.PostSoba(soba) as CreatedAtRouteNegotiatedContentResult<SobaDto>;


            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.ID);
            Assert.AreEqual(result.Content.HotelID, soba.HotelID);
            TestProfile.De();
        }
                

        [TestMethod]
        public void PutSobaVracaOk()
        {
            var context = new TestHotelContext();
            context.Sobas = GetDemoSoba;
            var controller = new SobaController(context);

            SobaDto soba = new SobaDto { ID = 3, SobaTipID = 2, HotelID = 1 };

            IHttpActionResult result = controller.PutSoba(soba);
            
            Assert.IsInstanceOfType(result, typeof(OkResult));
            TestProfile.De();
        }


        [TestMethod]
        public void PutSobaVracaNotFound()
        {

            var context = new TestHotelContext();
            context.Sobas = GetDemoSoba;

            var controller = new SobaController(context);
            SobaDto soba = new SobaDto { ID = 99, SobaTipID = 2, HotelID = 1 };
            IHttpActionResult result = controller.PutSoba(soba);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            TestProfile.De();
        }

        [TestMethod]
        public void DeleteSobaVracaSobu()
        {
            var context = new TestHotelContext();
            context.Sobas = GetDemoSoba;

            var controller = new SobaController(context);

            // Act
            IHttpActionResult actionResult = controller.DeleteSoba(3);
            var contentResult = actionResult as OkNegotiatedContentResult<SobaDto>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.ID);
            TestProfile.De();
        }

        [TestMethod]
        public void DeleteSobaZaNepostojecuSobu()
        {
            var context = new TestHotelContext();
            context.Sobas = GetDemoSoba;

            var controller = new SobaController(context);
            
            IHttpActionResult actionResult = controller.DeleteSoba(99);            

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            TestProfile.De();
        }
    }
}
