﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EmpeekTask.Helpers.Abstract;
using EmpeekTask.Helpers.Concrete;
using EmpeekTask.Helpers.Entities;
using EmpeekTask.Controllers;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;

namespace EmpeekTask.Test
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void CanGetLogicalDrives()
        {
            PageInfo result = new PageInfo
            {
                CurrentPath = String.Empty,
                BrowserItems = new List<string>
                {
                    "C:\\",
                    "D:\\",
                    "E:\\",
                    "G:\\"
                }
            };
            Mock<IBrowserHelper> mock = new Mock<IBrowserHelper>();
            mock.Setup(m => m.GetLogicalDrives()).Returns(result);
            var controller = new BrowserController(mock.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.GetDrives();

            PageInfo pageInfo;
            Assert.IsTrue(response.TryGetContentValue<PageInfo>(out pageInfo));
            Assert.AreEqual("", pageInfo.CurrentPath);
            Assert.AreEqual(4, pageInfo.BrowserItems.Count);
            Assert.AreEqual("C:\\", pageInfo.BrowserItems[0]);
            Assert.AreEqual("D:\\", pageInfo.BrowserItems[1]);
            Assert.AreEqual("E:\\", pageInfo.BrowserItems[2]);
            Assert.AreEqual("G:\\", pageInfo.BrowserItems[3]);
        }

        [TestMethod]
        public void CanGetObjects()
        {
            PageInfo result = new PageInfo
            {
                CurrentPath = "basePath\\path",
                BrowserItems = new List<string>
                {
                    "Games",
                    "Software",
                    "Music",
                    "Films"
                }
            };
            Mock<IBrowserHelper> mock = new Mock<IBrowserHelper>();
            mock.Setup(m => m.GetItemsForSelectedPath("basePath\\path")).Returns(result);
            var controller = new BrowserController(mock.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.GetObjects("basePath", "path");



            PageInfo pageInfo;
            Assert.IsTrue(response.TryGetContentValue<PageInfo>(out pageInfo));

            Assert.AreEqual(result.BrowserItems[2], pageInfo.BrowserItems[2]);
            Assert.AreEqual(4, pageInfo.BrowserItems.Count);
        }
    }
}
