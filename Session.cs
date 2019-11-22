using System;
using Nancy;
using Nancy.Conventions;
using Nancy.Session;

namespace TestNancy
{
    public class MyBootstrap : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            //跨域
            pipelines.AfterRequest.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                    .WithHeader("Access-Control-Allow-Methods", "POST,GET,OPTIONS")
                    .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");
            });

            //全局错误日志
            //pipelines.OnError += (ctx, ex) =>
            //{
            //    Console.WriteLine(ex.Message);
            //    return new Response();
            //};

            CookieBasedSessions.Enable(pipelines);
            base.ApplicationStartup(container, pipelines);
        }



        //protected override void RequestStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines, NancyContext context)
        //{
        //    pipelines.BeforeRequest += (ctx) =>
        //    {
        //        return null;
        //    };


        //    pipelines.AfterRequest += (ctx) =>
        //    {
                
        //    };

        //    //全局错误日志
        //    pipelines.OnError += (ctx, ex) =>
        //    {
        //        Console.WriteLine(ex.Message);
        //        return new Response();
        //    };

        //    base.RequestStartup(container, pipelines, context);
        //}

    }
}
