using System;
using System.Reflection; // Обов'язково для доступу до приватних методів
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalaizerClassLibrary;

namespace Test_automation_lab1_7__303
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("System.Data.SqlClient",
                    @"Data Source=.;Initial Catalog=CalculatorTestsDB;Integrated Security=True",
                    "SymbolTests",
                    DataAccessMethod.Sequential)]
        public void Test_IsOperator_And_IsDelimeter()
        {
            // 1. Отримуємо дані з БД (використовуємо індекси колонок: 1, 2, 3)
            string inputStr = TestContext.DataRow[1].ToString();
            bool expectedIsOperator = Convert.ToBoolean(TestContext.DataRow[2]);
            bool expectedIsDelimeter = Convert.ToBoolean(TestContext.DataRow[3]);

            // Готуємо char для методу IsDelimeter
            char inputChar = inputStr.Length > 0 ? inputStr[0] : ' ';

            // 2. Отримуємо доступ до приватних методів через Рефлексію
            MethodInfo isOperatorMethod = typeof(AnalaizerClass).GetMethod("IsOperator", BindingFlags.NonPublic | BindingFlags.Static);
            MethodInfo isDelimeterMethod = typeof(AnalaizerClass).GetMethod("IsDelimeter", BindingFlags.NonPublic | BindingFlags.Static);

            // 3. Викликаємо методи. IsOperator приймає string, IsDelimeter приймає char
            bool actualIsOperator = (bool)isOperatorMethod.Invoke(null, new object[] { inputStr });
            bool actualIsDelimeter = (bool)isDelimeterMethod.Invoke(null, new object[] { inputChar });

            // 4. Порівнюємо фактичний результат з очікуваним із бази даних
            Assert.AreEqual(expectedIsOperator, actualIsOperator, $"Помилка IsOperator для: '{inputStr}'");
            Assert.AreEqual(expectedIsDelimeter, actualIsDelimeter, $"Помилка IsDelimeter для: '{inputStr}'");
        }
    }
}