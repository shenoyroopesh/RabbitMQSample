using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyNetQ;
using OrderModels;

namespace OrderWebApp.Controllers
{
    public class OrderController : Controller
    {
        IBus bus;

        public OrderController()
        {
            bus = RabbitHutch.CreateBus("host=localhost;username=guest;password=guest");
        }

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Order/Create

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.Id = Guid.NewGuid();

                order.SampleXML = @"<Item type=""Part"" action=""add"">
                      <item_number>999-888</item_number>
                      <description>Some Assy</description>
                    <Relationships>
                        <Item type=""Part BOM"" action=""add"">
                          <quantity>10</quantity>
                    <related_id>
                            <Item type=""Part"" action=""add"">
                              <item_number>123-456</item_number>
                              <description>1/4w 10% 10K Resistor</description>
                             </Item>
                          </related_id>
                        </Item>
                      </Relationships>
                    </Item>";

                //publish this to the queue
                using (var channel = bus.OpenPublishChannel())
                {
                    channel.Publish(order);
                }
                return RedirectToAction("Confirmed");
            }

            return View(order);
        }

        public ActionResult Confirmed()
        {
            return View();
        }
    }
}