using System;
using System.Web.Optimization;

namespace Durandal451v2 {
  public class DurandalBundleConfig {
    public static void RegisterBundles(BundleCollection bundles) {
      bundles.IgnoreList.Clear();
      AddDefaultIgnorePatterns(bundles.IgnoreList);

      bundles.Add(
        new StyleBundle("~/Content/css")
          .Include("~/Content/ie10mobile.css")
          .Include("~/Content/bootstrap.css")
          .Include("~/Content/smart_wizard.css")
          .Include("~/Content/smart_wizard_theme_dots.css")
          .Include("~/Content/select2.css")
          .Include("~/Content/bootstrap-theme.css")
          .Include("~/Content/font-awesome.min.css")
          .Include("~/Content/durandal.css")
          .Include("~/Content/starterkit.css")
          .Include("~/Content/toastr.min.css")
          .Include("~/Content/site.css")
          //.Include("~/Content/basic.css")
          .Include("~/Content/dropzone.css")
        // .Include("~/Content/categoryButton.scss")
        );
    }

    public static void AddDefaultIgnorePatterns(IgnoreList ignoreList) {
      if(ignoreList == null) {
        throw new ArgumentNullException("ignoreList");
      }

      ignoreList.Ignore("*.intellisense.js");
      ignoreList.Ignore("*-vsdoc.js");
      ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
      //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
      //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
    }
  }
}