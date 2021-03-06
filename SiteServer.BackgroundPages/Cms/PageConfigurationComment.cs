﻿using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using BaiRong.Core;
using BaiRong.Core.Model.Enumerations;
using SiteServer.CMS.Core;

namespace SiteServer.BackgroundPages.Cms
{
	public class PageConfigurationComment : BasePageCms
    {
        public DropDownList DdlIsCommentable;
        public PlaceHolder PhComments;
        public DropDownList DdlIsCheckComments;
        public DropDownList DdlIsAnonymousComments;

        public static string GetRedirectUrl(int publishmentSystemId)
        {
            return PageUtils.GetCmsUrl(nameof(PageConfigurationComment), new NameValueCollection
            {
                {"PublishmentSystemID", publishmentSystemId.ToString()}
            });
        }

        public void Page_Load(object sender, EventArgs e)
        {
            if (IsForbidden) return;

            PageUtils.CheckRequestParameter("PublishmentSystemID");

            if (IsPostBack) return;

            VerifySitePermissions(AppManager.Permissions.WebSite.Configration);

            ControlUtils.SelectSingleItemIgnoreCase(DdlIsCommentable, PublishmentSystemInfo.Additional.IsCommentable.ToString());
            ControlUtils.SelectSingleItemIgnoreCase(DdlIsCheckComments, PublishmentSystemInfo.Additional.IsCheckComments.ToString());
            ControlUtils.SelectSingleItemIgnoreCase(DdlIsAnonymousComments, PublishmentSystemInfo.Additional.IsAnonymousComments.ToString());
            PhComments.Visible = PublishmentSystemInfo.Additional.IsCommentable;
        }

        public void DdlIsCommentable_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            PhComments.Visible = EBooleanUtils.Equals(DdlIsCommentable.SelectedValue, EBoolean.True);
        }

        public override void Submit_OnClick(object sender, EventArgs e)
		{
		    if (!Page.IsPostBack || !Page.IsValid) return;

		    PublishmentSystemInfo.Additional.IsCommentable = TranslateUtils.ToBool(DdlIsCommentable.SelectedValue);
		    PublishmentSystemInfo.Additional.IsCheckComments = TranslateUtils.ToBool(DdlIsCheckComments.SelectedValue);
            PublishmentSystemInfo.Additional.IsAnonymousComments = TranslateUtils.ToBool(DdlIsAnonymousComments.SelectedValue);

            try
		    {
		        DataProvider.PublishmentSystemDao.Update(PublishmentSystemInfo);

		        Body.AddSiteLog(PublishmentSystemId, "修改评论管理设置");

		        SuccessMessage("评论管理设置修改成功！");
		    }
		    catch (Exception ex)
		    {
		        FailMessage(ex, "评论管理设置修改失败！");
		    }
		}
	}
}
