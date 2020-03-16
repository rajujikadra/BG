using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BG.EnumFile
{
    public class EnumType
    {
        public enum Token
        {
            grant_type,
            username,
            password
        }

        public enum StockColumnName
        {
            [Description("Stone ID")]
            StoneID,
            [Description("Cts")]
            Cts,
            [Description("Location")]
            Location,
            [Description("Report No")]
            ReportNo,
            [Description("Certificate")]
            CertificateName,
            [Description("Shape")]
            ShapeName,
            [Description("Size")]
            Size,
            [Description("Color")]
            ColorName,
            [Description("Purity")]
            Purity,
            [Description("Cut")]
            Cut,
            [Description("Polish")]
            Polish,
            [Description("Symmetry")]
            Symmetry,
            [Description("Flou.")]
            Flou,
            [Description("Rap")]
            Rap,
            [Description("Back")]
            Disc,
            [Description("Asking")]
            Asking,
            [Description("Amount")]
            Amount,
            [Description("S %")]
            SPer,
            [Description("S Rate")]
            SRate,
            [Description("S Amount")]
            SAmount,
            [Description("Length")]
            Length,
            [Description("Width")]
            Width,
            [Description("Depth")]
            Depth,
            [Description("Depth %")]
            DepthPer,
            [Description("Tab %")]
            TablePer,
            [Description("Crown Angle")]
            CrownAngle,
            [Description("Crown Height")]
            CrownHeight,
            [Description("Pav Angle")]
            PavAngle,
            [Description("Pav Height")]
            PavHeight,
            [Description("KeytoSymbol")]
            KeyToSymbol,
            [Description("Eye clean")]
            EyeClean,
            [Description("Girdle")]
            Girdle,
            [Description("Culet")]
            Culet,
            [Description("Star")]
            Star,
            [Description("Lower")]
            Lower,
            [Description("Milky")]
            Milky,
            [Description("Hearts & Arrow")]
            HA,
            [Description("Inscription")]
            Inscription,
            [Description("Comments")]
            Comments,
            [Description("VideoLink")]
            VideoLink,
            Sale,
            Broker,
            Hold,
            Basket,
            Inquiry
        }
    }
}