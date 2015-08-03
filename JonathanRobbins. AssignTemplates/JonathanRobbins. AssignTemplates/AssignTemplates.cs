using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;

namespace JonathanRobbins.AssignTemplates
{
    public class AssignTemplates : Command
    {
        public override void Execute(CommandContext context)
        {
            var selectedItem = context.Items.FirstOrDefault();
            if (selectedItem == null)
                return;

            string templateId = "{CC80011D-8EAE-4BFC-84F1-67ECD0223E9E}";

            TemplateItem newTemplate = new TemplateItem(Sitecore.Context.Database.GetItem(templateId));

            if (newTemplate != null)
            {
                try
                {
                    selectedItem.ChangeTemplate(newTemplate);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message, ex, this);
                    throw;
                }
            }

        }
    }
}
