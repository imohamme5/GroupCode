// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace Game2
{
    partial class levelOne
    {
        ImageBox imgLevelBG;
        Label lblHighscoreText;
        Label lblScore;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            imgLevelBG = new ImageBox();
            imgLevelBG.Name = "imgLevelBG";
            lblHighscoreText = new Label();
            lblHighscoreText.Name = "lblHighscoreText";
            lblScore = new Label();
            lblScore.Name = "lblScore";

            // levelOne
            this.BackgroundColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 0f / 255f);
            this.AddChildLast(imgLevelBG);
            this.AddChildLast(lblHighscoreText);
            this.AddChildLast(lblScore);

            // imgLevelBG
            imgLevelBG.Image = null;
            imgLevelBG.ImageScaleType = ImageScaleType.Center;

            // lblHighscoreText
            lblHighscoreText.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            lblHighscoreText.Font = new UIFont(FontAlias.System, 25, FontStyle.Bold);
            lblHighscoreText.TextTrimming = TextTrimming.Character;
            lblHighscoreText.LineBreak = LineBreak.Character;
            lblHighscoreText.HorizontalAlignment = HorizontalAlignment.Center;

            // lblScore
            lblScore.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            lblScore.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            lblScore.LineBreak = LineBreak.Character;
            lblScore.HorizontalAlignment = HorizontalAlignment.Center;

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.SetSize(315, 600);
                    this.Anchors = Anchors.None;

                    imgLevelBG.SetPosition(0, 0);
                    imgLevelBG.SetSize(200, 200);
                    imgLevelBG.Anchors = Anchors.None;
                    imgLevelBG.Visible = true;

                    lblHighscoreText.SetPosition(404, 63);
                    lblHighscoreText.SetSize(214, 36);
                    lblHighscoreText.Anchors = Anchors.None;
                    lblHighscoreText.Visible = true;

                    lblScore.SetPosition(404, 63);
                    lblScore.SetSize(214, 36);
                    lblScore.Anchors = Anchors.None;
                    lblScore.Visible = true;

                    break;

                default:
                    this.SetSize(600, 315);
                    this.Anchors = Anchors.None;

                    imgLevelBG.SetPosition(12, 54);
                    imgLevelBG.SetSize(439, 206);
                    imgLevelBG.Anchors = Anchors.None;
                    imgLevelBG.Visible = true;

                    lblHighscoreText.SetPosition(454, 121);
                    lblHighscoreText.SetSize(133, 36);
                    lblHighscoreText.Anchors = Anchors.None;
                    lblHighscoreText.Visible = true;

                    lblScore.SetPosition(454, 158);
                    lblScore.SetSize(133, 36);
                    lblScore.Anchors = Anchors.None;
                    lblScore.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            lblHighscoreText.Text = "Highscore";

            lblScore.Text = "#0000";
        }

        public void InitializeDefaultEffect()
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        public void StartDefaultEffect()
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        public static ListPanelItem Creator()
        {
            return new levelOne();
        }

    }
}
