﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample
{
    public class AccountControllerTestFixture
    {

        [Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.ValidateEmail(email);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test,
            TestCase("abcdabcd", false),
            TestCase("ABCD1234", false),
            TestCase("abcd1234", false),
            TestCase("abc1234", false),
            TestCase("AbCd1234", true)
        ]
        public void TestValidatePwd(string password, bool expectedResult)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.ValidatePassword(password);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [
        Test,
            TestCase("irf@uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "Abcd1234567"),
        ]
        public void TestRegisterHappyPath(string email, string password)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.Register(email, password);

            // Assert
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }
    }
}
