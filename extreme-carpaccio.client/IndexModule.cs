using System.IO;
using System.Text;

namespace xCarpaccio.client
{
    using Nancy;
    using System;
    using Nancy.ModelBinding;
    using System.Linq;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => "Salut c'est nous.";

            Post["/order"] = _ =>
            {
                using (var reader = new StreamReader(base.Request.Body, Encoding.UTF8))
                {
                    Console.WriteLine("Order received: {0}", reader.ReadToEnd());
                }

                var order = this.Bind<Order>();
                Bill bill = null;
                //TODO: do something with order and return a bill if possible
                // If you manage to get the result, return a Bill object (JSON serialization is done automagically)
                // Else return a HTTP 404 error : return Negotiate.WithStatusCode(HttpStatusCode.NotFound);

                for (int i = 0; i < order.Quantities.Length; i++)
                {
                    var sum = +order.Quantities[i] * order.Prices[i];
                }

                if(true)
                {
                    return bill;
                }
                else
                {
                    return Negotiate.WithStatusCode(HttpStatusCode.NotFound);   
                }

            };

            Post["/feedback"] = _ =>
            {
                var feedback = this.Bind<Feedback>();
                Console.Write("Type: {0}: ", feedback.Type);
                Console.WriteLine(feedback.Content);
                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            };
        }

        private Bill sum(int[] quantities)
        {
            throw new NotImplementedException();
        }
    }
}