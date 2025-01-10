namespace Shopping.Web.Handlers
{
    public class RefitLoggingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Request: {request}");
            if (request.Content != null)
            {
                Console.WriteLine($"Request Content: {await request.Content.ReadAsStringAsync()}");
            }

            var response = await base.SendAsync(request, cancellationToken);

            Console.WriteLine($"Response: {response}");
            if (response.Content != null)
            {
                Console.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
            }

            return response;
        }
    }
}