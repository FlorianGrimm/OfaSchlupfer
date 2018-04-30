namespace OfaSchlupfer.StringTemplate {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using global::Antlr4.StringTemplate;

    using global::Antlr4.StringTemplate.Misc;

    public class Utility {
        public string Gna() {
            var t = new Template("a <a.value: {x | [<x>]}; separator=\", \">", '<', '>');
            //t.Add("a", "1");
            //t.Add("a", "2");
            t.Add("a", new { name="n", value=new List<string>() { "eins", "zwei"} });
            var act = t.Render();
            //var group = new TemplateGroup();
            //group.DefineTemplate("name", "template <a>");

            //Template st = group.GetInstanceOf("name");

            //st.Add("a", "b");
            //var act = st.Render(System.Globalization.CultureInfo.GetCultureInfo(9));
            return act;
        }
    }
}
