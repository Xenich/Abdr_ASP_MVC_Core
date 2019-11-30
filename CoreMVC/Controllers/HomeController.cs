using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMVC.Models;
using System.IO;
using Newtonsoft.Json;

namespace CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]      // данный атрибут указывает, что этот метод будет обрабатывать Get-запросы
        public IActionResult productChoosed(string product) // после того, как выбран товар, ищем склад и возвращаем форму со складом
        {
                // запрос к базе данных
            ViewData["ProductName"] = product;
            ViewData["wareHouseName"] = "Наименование склада";
            ViewData["wareHouseAddress"] = "Адрес склада";
            return View();      // карточка товара
        }

        [HttpPost]
        public string Addproduct()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string json = sr.ReadToEnd();
            Product product = JsonConvert.DeserializeObject<Product>(json);

            /*product.availability = int.Parse(Request.Form["availability"]);
            product.price = int.Parse(Request.Form["price"]);
            product.self = Boolean.Parse(Request.Form["self"]);
            product.byCity= Boolean.Parse(Request.Form["byCity"]);
            product.regions= Boolean.Parse(Request.Form["byCity"]);*/
            string discount = "Специальные цены"+ Environment.NewLine;
            foreach (int key in product.discount.Keys)
            {
                discount += "Если заказ более" + key.ToString() + " шт., то скидка " + product.discount[key] + "%" + Environment.NewLine;
            }
            return "Кол-во на складе: " + product.availability.ToString() +
            Environment.NewLine + "Цена: " +product.price.ToString() +
            Environment.NewLine + "Самовывоз:  " + product.self +
            Environment.NewLine + "Доставка по городу: " + product.byCity.ToString() +
            Environment.NewLine + "Доставка в другие регионы: " + product.regions.ToString() +
            Environment.NewLine + discount +
            // добавляем в базу данных
            Environment.NewLine + "Товар добавлен на склад";
        }
    }
}
