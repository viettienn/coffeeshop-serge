using CoffeeShop.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CoffeeShop.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/frameworks").Include(
                "~/Scripts/jquery-2.2.3.js",
                "~/Scripts/alertify/alertify.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-animate.min.js",
                "~/Scripts/angular-aria.min.js",
                "~/Scripts/angular-messages.min.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/angular-sanitize.min.js",
                "~/Scripts/angular-material/angular-material.js",
                //"~/Scripts/bootstrap.js",
                //"~/Scripts/Jasmine/*.js",
                "~/Scripts/angular-mocks.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js"));


            bundles.Add(new ScriptBundle("~/bundles/webclient").Include(
                "~/Client/init/*.js",
                "~/Client/home/*.js",
                "~/Client/beverage/*.js",
                "~/Client/order/*.js",
                "~/Client/lib/*.js",
                //"~/Client/directives/*.js",
                "~/Client/services/*.js"));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/*.css",
                "~/Content/alertify/alertify.core.css",
                "~/Content/alertify/alertify.default.css"));

            // Add transformer to all bundles
            foreach (var b in bundles)
                b.Transforms.Add(new VersionTransform());

        }
    }
}