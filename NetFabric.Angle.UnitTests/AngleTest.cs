﻿using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleTests
    {
        [Fact]
        public void InRadiansCreatesAngleCorrectly()
        {
            Angle.InRadians(0.0).Radians.Should().Be(0.0);
            Angle.InRadians(Math.PI).Radians.Should().Be(Math.PI);
            Angle.InRadians(double.NaN).Radians.Should().Be(double.NaN);
            Angle.InRadians(DegreesAngle.Right).Should().Be(RadiansAngle.Right);
            Angle.InRadians(GradiansAngle.Right).Should().Be(RadiansAngle.Right);
        }

        [Fact]
        public void InDegreesCreatesAngleCorrectly()
        {
            Angle.InDegrees(0.0).Degrees.Should().Be(0.0);
            Angle.InDegrees(90.0).Degrees.Should().Be(90.0);
            Angle.InDegrees(double.NaN).Degrees.Should().Be(double.NaN);
            Angle.InDegrees(RadiansAngle.Right).Should().Be(DegreesAngle.Right);
            Angle.InDegrees(GradiansAngle.Right).Should().Be(DegreesAngle.Right);
        }

        [Fact]
        public void InGradiansCreatesAngleCorrectly()
        {
            Angle.InGradians(0.0).Gradians.Should().Be(0.0);
            Angle.InGradians(Math.PI).Gradians.Should().Be(Math.PI);
            Angle.InGradians(double.NaN).Gradians.Should().Be(double.NaN);
            Angle.InGradians(RadiansAngle.Right).Should().Be(GradiansAngle.Right);
            Angle.InGradians(DegreesAngle.Right).Should().Be(GradiansAngle.Right);
        }

        /*
        [Fact]
        public void ToStringIsDefinedCorrectly()
        {
#if NET35
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
#else
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
#endif

            RadiansAngle.Straight.ToString().Should().Be("3.14159265358979");

            RadiansAngle.Straight.ToString("R").Should().Be("3.14159265358979");
            RadiansAngle.Straight.ToString("D").Should().Be("180°");
            Angle.InRadians(12, 34.56).ToString("M").Should().Be("12° 34.56'");
            Angle.InRadians(12, 34, 56.78).ToString("S").Should().Be("12° 34' 56.7800000000018\"");
            RadiansAngle.Straight.ToString("G").Should().Be("200");

            RadiansAngle.Straight.ToString("R", new CultureInfo("pt-PT")).Should().Be("3,14159265358979");
            RadiansAngle.Straight.ToString("D", new CultureInfo("pt-PT")).Should().Be("180°");
            Angle.InRadians(12, 34.56).ToString("M", new CultureInfo("pt-PT")).Should().Be("12° 34,56'");
            Angle.InRadians(12, 34, 56.78).ToString("S", new CultureInfo("pt-PT")).Should().Be("12° 34' 56,7800000000018\"");
            RadiansAngle.Straight.ToString("G", new CultureInfo("pt-PT")).Should().Be("200");

            String.Format("Radians: {0:R}", RadiansAngle.Straight).Should().Be("Radians: 3.14159265358979");
            String.Format("Degrees: {0:D}", RadiansAngle.Straight).Should().Be("Degrees: 180°");
            String.Format("Degrees: {0:M}", Angle.InRadians(12, 34.56)).Should().Be("Degrees: 12° 34.56'");
            String.Format("Degrees: {0:S}", Angle.InRadians(12, 34, 56.78)).Should().Be("Degrees: 12° 34' 56.7800000000018\"");
            String.Format("Gradians: {0:G}", RadiansAngle.Straight).Should().Be("Gradians: 200");

            RadiansAngle.Straight.ToString("R2").Should().Be("3.14");
            RadiansAngle.Straight.ToString("D2").Should().Be("180.00°");
            Angle.InRadians(12, 34.56).ToString("M2").Should().Be("12° 34.56'");
            Angle.InRadians(12, 34, 56.78).ToString("S2").Should().Be("12° 34' 56.78\"");
            RadiansAngle.Straight.ToString("G2").Should().Be("200.00");

            RadiansAngle.Straight.ToString("R2", new CultureInfo("pt-PT")).Should().Be("3,14");
            RadiansAngle.Straight.ToString("D2", new CultureInfo("pt-PT")).Should().Be("180,00°");
            Angle.InRadians(12, 34.56).ToString("M2", new CultureInfo("pt-PT")).Should().Be("12° 34,56'");
            Angle.InRadians(12, 34, 56.78).ToString("S2", new CultureInfo("pt-PT")).Should().Be("12° 34' 56,78\"");
            RadiansAngle.Straight.ToString("G2", new CultureInfo("pt-PT")).Should().Be("200,00");

            String.Format(new CultureInfo("pt-PT"), "Radians: {0:R2}", RadiansAngle.Straight).Should().Be("Radians: 3,14");
            String.Format(new CultureInfo("pt-PT"), "Degrees: {0:D2}", RadiansAngle.Straight).Should().Be("Degrees: 180,00°");
            String.Format(new CultureInfo("pt-PT"), "Degrees: {0:M2}", Angle.InRadians(12, 34.56)).Should().Be("Degrees: 12° 34,56'");
            String.Format(new CultureInfo("pt-PT"), "Degrees: {0:S2}", Angle.InRadians(12, 34, 56.78)).Should().Be("Degrees: 12° 34' 56,78\"");
            String.Format(new CultureInfo("pt-PT"), "Gradians: {0:G2}", RadiansAngle.Straight).Should().Be("Gradians: 200,00");

        }
*/

    }
}
