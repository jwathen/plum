using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;
using Should;
using System.Web.Mvc;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Web;
using Plum.Controllers;
using Plum.Tests.TestHelpers.Mocks;
using System.Web.Routing;
using System.Linq.Expressions;

namespace Plum.Tests.TestHelpers.Mvc
{
    public static class FluentMvcTestingExtensions
    {
        public static TController WithModelValidation<TController, TModel>(this TController controller, TModel model, IValidator<TModel> validator) where TController : AppControllerBase
        {
            var validationResult = validator.Validate(model);
            foreach (var error in validationResult.Errors)
            {
                controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return controller;
        }

        public static TController WithModelValidation<TController, TModel>(this TController controller, TModel model) where TController : AppControllerBase
        {
            var attribute = model.GetType().GetCustomAttributes(typeof(ValidatorAttribute), true).Cast<ValidatorAttribute>().FirstOrDefault();
            if (attribute != null)
            {
                var validator = (IValidator<TModel>)Activator.CreateInstance(attribute.ValidatorType);
                return controller.WithModelValidation(model, validator);
            }
            return controller;
        }

        public static RenderedHtmlResultTest<TController> ShouldRenderDefaultViewHtml<TController> (this ControllerResultTest<TController> testResult) 
            where TController : AppControllerBase
        {
            ViewResultTest viewResultTest = testResult.ShouldRenderDefaultView();
            return RenderView(testResult, viewResultTest);
        }

        public static RenderedHtmlResultTest<TController> ShouldRenderViewHtml<TController>(this ControllerResultTest<TController> testResult, string viewName)
            where TController : AppControllerBase
        {
            ViewResultTest viewResultTest = testResult.ShouldRenderView(viewName);
            return RenderView(testResult, viewResultTest);
        }

        public static RenderedHtmlResultTest<TController> ShouldRenderPartialViewHtml<TController>(this ControllerResultTest<TController> testResult, string viewName)
            where TController : AppControllerBase
        {
            ViewResultTest viewResultTest = testResult.ShouldRenderPartialView(viewName);
            return RenderPartialView(testResult, viewResultTest);
        }

        public static RenderedHtmlResultTest<TController> ShouldMatchCss<TController>(this RenderedHtmlResultTest<TController> testResult, string cssSelector, int? expectedCount = null)
            where TController : AppControllerBase
        {
            var matchingNodes = testResult.HtmlDocument.QuerySelectorAll(cssSelector);
            if ((matchingNodes == null || !matchingNodes.Any()))
            {
                throw new Exception($"Expected elements to match {cssSelector} but found none.");
            }

            if (expectedCount.HasValue)
            {
                if (matchingNodes.Count() != expectedCount.Value)
                {
                    throw new Exception($"Expected {expectedCount} elements to match {cssSelector} but found {matchingNodes.Count()}.");
                }
            }

            return testResult;
        }

        public static RenderedHtmlResultTest<TController> ShouldMatchXPath<TController>(this RenderedHtmlResultTest<TController> testResult, string xpathSelector, int? expectedCount = null)
            where TController : AppControllerBase
        {
            var matchingNodes = testResult.HtmlDocument.SelectNodes(xpathSelector);
            if ((matchingNodes == null || !matchingNodes.Any()))
            {
                throw new Exception($"Expected elements to match {xpathSelector} but found none.");
            }

            
            if (expectedCount.HasValue)
            {
                if (matchingNodes.Count() != expectedCount.Value)
                {
                    throw new Exception($"Expected {expectedCount} elements to match {xpathSelector} but found {matchingNodes.Count()}.");
                }
            }

            return testResult;
        }

        public static RenderedHtmlResultTest<TController> ShouldContainText<TController>(this RenderedHtmlResultTest<TController> testResult, params string[] text)
            where TController : AppControllerBase
        {
            foreach(string item in text)
            {
                testResult.HtmlDocument.InnerText.ShouldContain(HttpUtility.HtmlEncode(item));
            }
            return testResult;
        }

        public static RenderedHtmlResultTest<TController> ShouldContainHtml<TController>(this RenderedHtmlResultTest<TController> testResult, string html)
    where TController : AppControllerBase
        {
            testResult.Html.ShouldContain(html);
            return testResult;
        }

        public static ControllerResultTest<TController> ShouldRedirectTo<TController>(this ControllerResultTest<TController> testResult, string controller, string action, object routeValues = null)
            where TController : AppControllerBase
        {
            var actionResult = testResult.ActionResult as RedirectToRouteResult;
            if (actionResult == null)
            {
                throw new InvalidCastException($"Expected action result of type RedirectToRouteResult but got type {testResult.ActionResult.GetType().Name}");
            }
            actionResult.RouteValues["controller"].ShouldEqual(controller);
            actionResult.RouteValues["action"].ShouldEqual(action);
            if (routeValues != null)
            {
                var dictionary = new RouteValueDictionary(routeValues);
                foreach (string key in dictionary.Keys)
                {
                    object expected = dictionary[key];
                    object actual = actionResult.RouteValues[key];
                    dictionary[key].ShouldEqual(actionResult.RouteValues[key], $"Expected route value for \"{key}\" to equal {ToStringOrNull(expected)} but it was {ToStringOrNull(actual)}.");
                }
            }
            return testResult;
        }

        public static ControllerResultTest<TController> ShouldRedirectTo<TController>(this ControllerResultTest<TController> testResult, string action, object routeValues = null)
            where TController : AppControllerBase
        {
            string controller = typeof(TController).Name.Replace("Controller", string.Empty);
            return testResult.ShouldRedirectTo(controller, action, routeValues);
        }

        public static ControllerResultTest<TController> ShouldReturnJavaScriptResult<TController>(this ControllerResultTest<TController> testResult, Action<string> scriptAssertion = null)
            where TController : AppControllerBase
        {
            var actionResult = testResult.ActionResult as JavaScriptResult;
            if (actionResult == null)
            {
                throw new InvalidCastException($"Expected action result of type JavaScriptResult but got type {testResult.ActionResult.GetType().Name}");
            }

            if (scriptAssertion != null)
            {
                scriptAssertion(actionResult.Script);
            }

            return testResult;
        }
        public static ControllerResultTest<TController> ShouldJavaScriptRedirectTo<TController>(this ControllerResultTest<TController> testResult, string url)
            where TController : AppControllerBase
        {
            string expectedScript = $"window.location.href = '{url}';";
            string expectedContent = $"<script>{expectedScript}</script>";
            testResult.ShouldReturnContent(expectedContent, "text/html");
            return testResult;
        }

        private static RenderedHtmlResultTest<TController> RenderView<TController>(ControllerResultTest<TController> controllerResultTest, ViewResultTest viewResultTest)
             where TController : AppControllerBase
        {
            string controllerName = controllerResultTest.Controller.GetType().Name.Replace("Controller", string.Empty);
            controllerResultTest.Controller.ControllerContext.RouteData.Values.Add("controller", controllerName);
            controllerResultTest.Controller.ControllerContext.RouteData.Values.Add("action", controllerResultTest.ActionName);

            ViewResult viewResult = (ViewResult)controllerResultTest.ActionResult;
            try
            {
                viewResult.ExecuteResult(controllerResultTest.Controller.ControllerContext);
            }
            catch (ArgumentException ex) when (ExceptionLooksLikeACallToHtmlAntiForgeryToken(ex))
            {
                throw new InvalidOperationException("Html.AntiForgeryToken can't be used in integration tests.  Use Html.AntiForgeryToken2 instead. (in Plum.Web.HtmlHelperExtensions)");
            }
            catch (InvalidOperationException ex) when (ExceptionLooksLikeAChildAction(ex))
            {
                throw new InvalidOperationException("\"No route in the route table matches the supplied values.\" was thrown.  If this was the result of a call to a child action then change the call to use the T4MVC helper or change assertion back to ShouldRenderView/ShouldRenderPartialView insetad of ShouldRenderViewHtml/ShouldRenderViewHtml.", ex);
            }

            var mockHttpResponse = (MockHttpResponse)controllerResultTest.Controller.Response;

            return new RenderedHtmlResultTest<TController>(controllerResultTest, viewResultTest, mockHttpResponse.OutputHtml);
        }

        private static RenderedHtmlResultTest<TController> RenderPartialView<TController>(ControllerResultTest<TController> controllerResultTest, ViewResultTest viewResultTest)
             where TController : AppControllerBase
        {
            string controllerName = controllerResultTest.Controller.GetType().Name.Replace("Controller", string.Empty);
            controllerResultTest.Controller.ControllerContext.RouteData.Values.Add("controller", controllerName);
            controllerResultTest.Controller.ControllerContext.RouteData.Values.Add("action", controllerResultTest.ActionName);

            PartialViewResult viewResult = (PartialViewResult)controllerResultTest.ActionResult;
            try
            {
                viewResult.ExecuteResult(controllerResultTest.Controller.ControllerContext);
            }
            catch (ArgumentException ex) when (ExceptionLooksLikeACallToHtmlAntiForgeryToken(ex))
            {
                throw new InvalidOperationException("Html.AntiForgeryToken can't be used in integration tests.  Use Html.AntiForgeryToken2 instead. (in Plum.Web.HtmlHelperExtensions)");
            }
            catch (InvalidOperationException ex) when (ExceptionLooksLikeAChildAction(ex))
            {
                throw new InvalidOperationException("\"No route in the route table matches the supplied values.\" was thrown.  If this was the result of a call to a child action then change the call to use the T4MVC helper or change assertion back to ShouldRenderView/ShouldRenderPartialView insetad of ShouldRenderViewHtml/ShouldRenderViewHtml.", ex);
            }

            var mockHttpResponse = (MockHttpResponse)controllerResultTest.Controller.Response;

            return new RenderedHtmlResultTest<TController>(controllerResultTest, viewResultTest, mockHttpResponse.OutputHtml);
        }

        private static bool ExceptionLooksLikeAChildAction(InvalidOperationException ex)
        {
            return ex.Message.StartsWith("No route in the route table matches the supplied values.");
        }

        private static bool ExceptionLooksLikeACallToHtmlAntiForgeryToken(ArgumentException ex)
        {
            return ex.Message.StartsWith("An HttpContext is required to perform this operation.")
                && ex.StackTrace.Contains("System.Web.Helpers.AntiForgery.GetHtml()");
        }

        private static string ToStringOrNull(object value)
        {
            if (value == null)
            {
                return "(null)";
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
