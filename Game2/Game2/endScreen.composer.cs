// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace endScreen
{
    partial class endScreen
    {
        Panel sceneBackgroundPanel;
        Label lblTitleComplete;
        Button btnRetry;
        Button btnMenu;
        Button btnLevelSelect;
        Label lblHighscore;
        Label lblTitleHighscore;
        Label lblScore;
        Label lblTitleScore;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            sceneBackgroundPanel = new Panel();
            sceneBackgroundPanel.Name = "sceneBackgroundPanel";
            lblTitleComplete = new Label();
            lblTitleComplete.Name = "lblTitleComplete";
            btnRetry = new Button();
            btnRetry.Name = "btnRetry";
            btnMenu = new Button();
            btnMenu.Name = "btnMenu";
            btnLevelSelect = new Button();
            btnLevelSelect.Name = "btnLevelSelect";
            lblHighscore = new Label();
            lblHighscore.Name = "lblHighscore";
            lblTitleHighscore = new Label();
            lblTitleHighscore.Name = "lblTitleHighscore";
            lblScore = new Label();
            lblScore.Name = "lblScore";
            lblTitleScore = new Label();
            lblTitleScore.Name = "lblTitleScore";

            // sceneBackgroundPanel
            sceneBackgroundPanel.BackgroundColor = new UIColor(174f / 255f, 172f / 255f, 172f / 255f, 178f / 255f);

            // endScreen
            this.RootWidget.AddChildLast(sceneBackgroundPanel);
            this.RootWidget.AddChildLast(lblTitleComplete);
            this.RootWidget.AddChildLast(btnRetry);
            this.RootWidget.AddChildLast(btnMenu);
            this.RootWidget.AddChildLast(btnLevelSelect);
            this.RootWidget.AddChildLast(lblHighscore);
            this.RootWidget.AddChildLast(lblTitleHighscore);
            this.RootWidget.AddChildLast(lblScore);
            this.RootWidget.AddChildLast(lblTitleScore);
            this.Transition = new CrossFadeTransition();

            // lblTitleComplete
            lblTitleComplete.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            lblTitleComplete.Font = new UIFont(FontAlias.System, 72, FontStyle.Bold);
            lblTitleComplete.LineBreak = LineBreak.Character;
            lblTitleComplete.HorizontalAlignment = HorizontalAlignment.Center;

            // btnRetry
            btnRetry.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            btnRetry.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);

            // btnMenu
            btnMenu.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            btnMenu.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);

            // btnLevelSelect
            btnLevelSelect.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            btnLevelSelect.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);

            // lblHighscore
            lblHighscore.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            lblHighscore.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            lblHighscore.LineBreak = LineBreak.Character;

            // lblTitleHighscore
            lblTitleHighscore.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            lblTitleHighscore.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            lblTitleHighscore.LineBreak = LineBreak.Character;

            // lblScore
            lblScore.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            lblScore.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            lblScore.LineBreak = LineBreak.Character;

            // lblTitleScore
            lblTitleScore.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            lblTitleScore.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            lblTitleScore.LineBreak = LineBreak.Character;

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.DesignWidth = 544;
                    this.DesignHeight = 960;

                    sceneBackgroundPanel.SetPosition(0, 0);
                    sceneBackgroundPanel.SetSize(544, 960);
                    sceneBackgroundPanel.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                    sceneBackgroundPanel.Visible = true;

                    lblTitleComplete.SetPosition(151, 101);
                    lblTitleComplete.SetSize(214, 36);
                    lblTitleComplete.Anchors = Anchors.None;
                    lblTitleComplete.Visible = true;

                    btnRetry.SetPosition(275, 310);
                    btnRetry.SetSize(214, 56);
                    btnRetry.Anchors = Anchors.None;
                    btnRetry.Visible = true;

                    btnMenu.SetPosition(349, 399);
                    btnMenu.SetSize(214, 56);
                    btnMenu.Anchors = Anchors.None;
                    btnMenu.Visible = true;

                    btnLevelSelect.SetPosition(349, 332);
                    btnLevelSelect.SetSize(214, 56);
                    btnLevelSelect.Anchors = Anchors.None;
                    btnLevelSelect.Visible = true;

                    lblHighscore.SetPosition(176, 184);
                    lblHighscore.SetSize(214, 36);
                    lblHighscore.Anchors = Anchors.None;
                    lblHighscore.Visible = true;

                    lblTitleHighscore.SetPosition(198, 182);
                    lblTitleHighscore.SetSize(214, 36);
                    lblTitleHighscore.Anchors = Anchors.None;
                    lblTitleHighscore.Visible = true;

                    lblScore.SetPosition(176, 184);
                    lblScore.SetSize(214, 36);
                    lblScore.Anchors = Anchors.None;
                    lblScore.Visible = true;

                    lblTitleScore.SetPosition(198, 182);
                    lblTitleScore.SetSize(214, 36);
                    lblTitleScore.Anchors = Anchors.None;
                    lblTitleScore.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

                    sceneBackgroundPanel.SetPosition(0, 0);
                    sceneBackgroundPanel.SetSize(960, 544);
                    sceneBackgroundPanel.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                    sceneBackgroundPanel.Visible = true;

                    lblTitleComplete.SetPosition(129, 41);
                    lblTitleComplete.SetSize(702, 100);
                    lblTitleComplete.Anchors = Anchors.None;
                    lblTitleComplete.Visible = true;

                    btnRetry.SetPosition(372, 261);
                    btnRetry.SetSize(214, 56);
                    btnRetry.Anchors = Anchors.None;
                    btnRetry.Visible = true;

                    btnMenu.SetPosition(373, 446);
                    btnMenu.SetSize(214, 56);
                    btnMenu.Anchors = Anchors.None;
                    btnMenu.Visible = true;

                    btnLevelSelect.SetPosition(373, 354);
                    btnLevelSelect.SetSize(214, 56);
                    btnLevelSelect.Anchors = Anchors.None;
                    btnLevelSelect.Visible = true;

                    lblHighscore.SetPosition(496, 205);
                    lblHighscore.SetSize(214, 36);
                    lblHighscore.Anchors = Anchors.None;
                    lblHighscore.Visible = true;

                    lblTitleHighscore.SetPosition(325, 205);
                    lblTitleHighscore.SetSize(140, 36);
                    lblTitleHighscore.Anchors = Anchors.None;
                    lblTitleHighscore.Visible = true;

                    lblScore.SetPosition(496, 156);
                    lblScore.SetSize(214, 36);
                    lblScore.Anchors = Anchors.None;
                    lblScore.Visible = true;

                    lblTitleScore.SetPosition(325, 156);
                    lblTitleScore.SetSize(140, 36);
                    lblTitleScore.Anchors = Anchors.None;
                    lblTitleScore.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            lblTitleComplete.Text = "Level Complete!";

            btnRetry.Text = "Retry";

            btnMenu.Text = "Main Menu";

            btnLevelSelect.Text = "Level Select";

            lblHighscore.Text = "#0000";

            lblTitleHighscore.Text = "Highscore";

            lblScore.Text = "#0000";

            lblTitleScore.Text = "Score";
        }

        private void onShowing(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        private void onShown(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

    }
}
