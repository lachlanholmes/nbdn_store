using System;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_a_request_from(HttpContext http_context)
        {
            return new StubRequest();
        }

        public class StubRequest : Request
        {
            public InputModel map<InputModel>()
            {
                throw new NotImplementedException();
            }
        }
    }
}