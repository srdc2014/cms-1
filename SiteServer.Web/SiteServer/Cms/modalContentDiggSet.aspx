﻿<%@ Page Language="C#" Inherits="SiteServer.BackgroundPages.Cms.ModalContentDiggSet" Trace="false"%>
  <%@ Register TagPrefix="ctrl" Namespace="SiteServer.BackgroundPages.Controls" Assembly="SiteServer.BackgroundPages" %>
    <!DOCTYPE html>
    <html class="modalPage">

    <head>
      <meta charset="utf-8">
      <!--#include file="../inc/head.html"-->
    </head>

    <body>
      <form runat="server">
        <ctrl:alerts runat="server" />

        <div class="form-group form-row">
          <label class="col-3 col-form-label text-right">赞同数</label>
          <div class="col-8">
            <asp:TextBox class="form-control" MaxLength="50" id="TbGoodNum" runat="server" />
          </div>
          <div class="col-1">
            <asp:RequiredFieldValidator ControlToValidate="TbGoodNum" errorMessage=" *" foreColor="red" display="Dynamic" runat="server"
            />
            <asp:RegularExpressionValidator ControlToValidate="TbGoodNum" ValidationExpression="\d+" Display="Dynamic" ErrorMessage="赞同数必须为数字"
              foreColor="red" runat="server" />
          </div>
        </div>

        <div class="form-group form-row">
          <label class="col-3 col-form-label text-right">不赞同数</label>
          <div class="col-8">
            <asp:TextBox class="form-control" MaxLength="50" Text="0" id="TbBadNum" runat="server" />
          </div>
          <div class="col-1">
            <asp:RequiredFieldValidator ControlToValidate="TbBadNum" errorMessage=" *" foreColor="red" display="Dynamic" runat="server"
            />
            <asp:RegularExpressionValidator ControlToValidate="TbBadNum" ValidationExpression="[\d\.]+" Display="Dynamic" ErrorMessage="不赞同数必须为数字,可以带小数点"
              foreColor="red" runat="server" />
          </div>
        </div>

        <hr />

        <div class="text-right mr-1">
          <asp:Button class="btn btn-primary m-l-5" Text="确 定" OnClick="Submit_OnClick" runat="server" />
          <button type="button" class="btn btn-default m-l-5" onclick="window.parent.layer.closeAll()">取 消</button>
        </div>

      </form>
    </body>

    </html>