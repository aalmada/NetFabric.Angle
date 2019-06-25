﻿using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleDegreesTests
    {
        static readonly AngleDegrees AcuteAngle = AngleDegrees.Right / 2.0;

        public static TheoryData<AngleRadians, AngleDegrees> AngleRadiansData = new TheoryData<AngleRadians, AngleDegrees>
        {
            { -AngleRadians.Full, -AngleDegrees.Full },
            { -AngleRadians.Straight, -AngleDegrees.Straight },
            { -AngleRadians.Right, -AngleDegrees.Right },
            { AngleRadians.Zero, AngleDegrees.Zero },
            { AngleRadians.Right, AngleDegrees.Right },
            { AngleRadians.Straight, AngleDegrees.Straight },
            { AngleRadians.Full, AngleDegrees.Full },
        };

        [Theory]
        [MemberData(nameof(AngleRadiansData))]
        public void ToDegrees_When_AngleRadians_Should_Succeed(AngleRadians value, AngleDegrees expected)
        {
            // arrange

            // act
            var angle = Angle.InDegrees(value);

            // assert
            angle.Should().BeOfType<AngleDegrees>().And.Be(expected);
        }

        public static TheoryData<AngleGradians, AngleDegrees> AngleGradiansData = new TheoryData<AngleGradians, AngleDegrees>
        {
            { -AngleGradians.Full, -AngleDegrees.Full },
            { -AngleGradians.Straight, -AngleDegrees.Straight },
            { -AngleGradians.Right, -AngleDegrees.Right },
            { AngleGradians.Zero, AngleDegrees.Zero },
            { AngleGradians.Right, AngleDegrees.Right },
            { AngleGradians.Straight, AngleDegrees.Straight },
            { AngleGradians.Full, AngleDegrees.Full },
        };

        [Theory]
        [MemberData(nameof(AngleGradiansData))]
        public void ToDegrees_When_AngleGradians_Should_Succeed(AngleGradians value, AngleDegrees expected)
        {
            // arrange

            // act
            var angle = Angle.InDegrees(value);

            // assert
            angle.Should().BeOfType<AngleDegrees>().And.Be(expected);
        }

        public static TheoryData<AngleDegreesMinutes, AngleDegrees> AngleDegreesMinutesData = new TheoryData<AngleDegreesMinutes, AngleDegrees>
        {
            { -AngleDegreesMinutes.Full, -AngleDegrees.Full },
            { -AngleDegreesMinutes.Straight, -AngleDegrees.Straight },
            { -AngleDegreesMinutes.Right, -AngleDegrees.Right },
            { AngleDegreesMinutes.Zero, AngleDegrees.Zero },
            { AngleDegreesMinutes.Right, AngleDegrees.Right },
            { AngleDegreesMinutes.Straight, AngleDegrees.Straight },
            { AngleDegreesMinutes.Full, AngleDegrees.Full },
        };

        [Theory]
        [MemberData(nameof(AngleDegreesMinutesData))]
        public void ToDegrees_When_AngleDegreesMinutes_Should_Succeed(in AngleDegreesMinutes value, AngleDegrees expected)
        {
            // arrange

            // act
            var angle = Angle.InDegrees(value);

            // assert
            angle.Should().BeOfType<AngleDegrees>().And.Be(expected);
        }

        public static TheoryData<AngleDegrees, object, Comparison> CompareInvalidData => new TheoryData<AngleDegrees, object, Comparison>
        {
            { AngleDegrees.Right, null, Comparison.Invalid },
            { AngleDegrees.Right, 90.0, Comparison.Invalid },
        };

        public static TheoryData<AngleDegrees, AngleDegrees, Comparison> CompareData => new TheoryData<AngleDegrees, AngleDegrees, Comparison>
        {
            { Angle.InDegrees(-10.0), Angle.InDegrees(-10.001), Comparison.GreaterThan },
            { Angle.InDegrees(-10.0), Angle.InDegrees(-9.999), Comparison.LessThan },
            { Angle.InDegrees(10.0), Angle.InDegrees(10.001), Comparison.LessThan },
            { Angle.InDegrees(10.0), Angle.InDegrees(9.999), Comparison.GreaterThan },

            { AngleDegrees.Zero, AngleDegrees.Right - AngleDegrees.Full, Comparison.GreaterThan },
            { AngleDegrees.Right, AngleDegrees.Right - AngleDegrees.Full, Comparison.GreaterThan },
            { AngleDegrees.Straight, AngleDegrees.Right - AngleDegrees.Full, Comparison.GreaterThan },

            { AngleDegrees.Zero, AngleDegrees.Right, Comparison.LessThan },
            { AngleDegrees.Right, AngleDegrees.Right, Comparison.Equal },
            { AngleDegrees.Straight, AngleDegrees.Right, Comparison.GreaterThan },

            { AngleDegrees.Zero, AngleDegrees.Right + AngleDegrees.Full, Comparison.LessThan },
            { AngleDegrees.Right, AngleDegrees.Right + AngleDegrees.Full, Comparison.LessThan },
            { AngleDegrees.Straight, AngleDegrees.Right + AngleDegrees.Full, Comparison.LessThan },
        };

        public static TheoryData<AngleDegrees, AngleDegrees, Comparison> CompareReducedData => new TheoryData<AngleDegrees, AngleDegrees, Comparison>
        {
            { Angle.InDegrees(-10.0), Angle.InDegrees(-10.001), Comparison.GreaterThan },
            { Angle.InDegrees(-10.0), Angle.InDegrees(-9.999), Comparison.LessThan },
            { Angle.InDegrees(10.0), Angle.InDegrees(10.001), Comparison.LessThan },
            { Angle.InDegrees(10.0), Angle.InDegrees(9.999), Comparison.GreaterThan },

            { AngleDegrees.Zero, AngleDegrees.Right - AngleDegrees.Full, Comparison.LessThan },
            { AngleDegrees.Right, AngleDegrees.Right - AngleDegrees.Full, Comparison.Equal },
            { AngleDegrees.Straight, AngleDegrees.Right - AngleDegrees.Full, Comparison.GreaterThan },

            { AngleDegrees.Zero, AngleDegrees.Right, Comparison.LessThan },
            { AngleDegrees.Right, AngleDegrees.Right, Comparison.Equal },
            { AngleDegrees.Straight, AngleDegrees.Right, Comparison.GreaterThan },

            { AngleDegrees.Zero, AngleDegrees.Right + AngleDegrees.Full, Comparison.LessThan },
            { AngleDegrees.Right, AngleDegrees.Right + AngleDegrees.Full, Comparison.Equal },
            { AngleDegrees.Straight, AngleDegrees.Right + AngleDegrees.Full, Comparison.GreaterThan },
        };

        [Theory]
        [MemberData(nameof(CompareInvalidData))]
        [MemberData(nameof(CompareData))]
        public void EqualsObject_Should_Succeed(AngleDegrees left, object right, Comparison comparison)
        {
            // arrange

            // act
            var result = left.Equals(right);

            // assert
            result.Should().Be(comparison == Comparison.Equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void Equals_Should_Succeed(AngleDegrees left, AngleDegrees right, Comparison comparison)
        {
            // arrange

            // act
            var result = left.Equals(right);

            // assert
            result.Should().Be(comparison == Comparison.Equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GetHashCode_Should_Succeed(AngleDegrees left, AngleDegrees right, Comparison comparison)
        {
            // arrange

            // act
            var result = left.GetHashCode();

            // assert
            if (comparison == Comparison.Equal)
                result.Should().Be(right.GetHashCode());
            else
                result.Should().NotBe(right.GetHashCode());
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void OperatorEquality_Should_Succeed(AngleDegrees left, AngleDegrees right, Comparison comparison)
        {
            // arrange

            // act
            var result = left == right;

            // assert
            result.Should().Be(comparison == Comparison.Equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void OperatorInequality_Should_Succeed(AngleDegrees left, AngleDegrees right, Comparison comparison)
        {
            // arrange

            // act
            var result = left != right;

            // assert
            result.Should().Be(comparison != Comparison.Equal);
        }

        [Theory]
        [MemberData(nameof(CompareInvalidData))]
        public void CompareTo_When_InvalidData_Should_Thrown(AngleDegrees angle, object obj, Comparison comparison)
        {
            // arrange

            // act
            Action act = () => ((IComparable)angle).CompareTo(obj);

            // assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Argument has to be an {nameof(AngleDegrees)}.\r\nParameter name: obj");
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void CompareTo_Should_Succeed(AngleDegrees left, AngleDegrees right, Comparison comparison)
        {
            // arrange

            // act
            var result = ((IComparable)left).CompareTo(right);

            // assert
            switch (comparison)
            {
                case Comparison.LessThan:
                    result.Should().BeNegative();
                    break;

                case Comparison.Equal:
                    result.Should().Be(0);
                    break;

                case Comparison.GreaterThan:
                    result.Should().BePositive();
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void Compare_Should_Succeed(AngleDegrees left, AngleDegrees right, Comparison comparison)
        {
            // arrange

            // act
            var result = Angle.Compare(left, right);

            // assert
            switch (comparison)
            {
                case Comparison.LessThan:
                    result.Should().BeNegative();
                    break;

                case Comparison.Equal:
                    result.Should().Be(0);
                    break;

                case Comparison.GreaterThan:
                    result.Should().BePositive();
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        [Theory]
        [MemberData(nameof(CompareReducedData))]
        public void CompareReduced_Should_Succeed(AngleDegrees left, AngleDegrees right, Comparison comparison)
        {
            // arrange

            // act
            var result = Angle.CompareReduced(left, right);

            // assert
            switch (comparison)
            {
                case Comparison.LessThan:
                    result.Should().BeNegative();
                    break;

                case Comparison.Equal:
                    result.Should().Be(0);
                    break;

                case Comparison.GreaterThan:
                    result.Should().BePositive();
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void LessThan_Should_Succeed(AngleDegrees left, AngleDegrees right, Comparison comparison)
        {
            // arrange

            // act
            var result = left < right;

            // assert
            result.Should().Be(comparison == Comparison.LessThan);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void LessThanOrEqual_Should_Succeed(AngleDegrees left, AngleDegrees right, Comparison comparison)
        {
            // arrange

            // act
            var result = left <= right;

            // assert
            result.Should().Be(comparison == Comparison.LessThan || comparison == Comparison.Equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GreaterThan_Should_Succeed(AngleDegrees left, AngleDegrees right, Comparison comparison)
        {
            // arrange

            // act
            var result = left > right;

            // assert
            result.Should().Be(comparison == Comparison.GreaterThan);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GreaterThanOrEqual_Should_Succeed(AngleDegrees left, AngleDegrees right, Comparison comparison)
        {
            // arrange

            // act
            var result = left >= right;

            // assert
            result.Should().Be(comparison == Comparison.GreaterThan || comparison == Comparison.Equal);
        }

        public static TheoryData<AngleDegrees, AngleDegrees> ReduceData => new TheoryData<AngleDegrees, AngleDegrees> {
            { AngleDegrees.Zero, AngleDegrees.Zero },
            { AcuteAngle, AcuteAngle },
            { AngleDegrees.Right, AngleDegrees.Right },
            { AngleDegrees.Right + AcuteAngle, AngleDegrees.Right + AcuteAngle },
            { AngleDegrees.Straight, AngleDegrees.Straight },

            { AngleDegrees.Full, AngleDegrees.Zero },
            { AngleDegrees.Full + AcuteAngle, AcuteAngle },
            { AngleDegrees.Full + AngleDegrees.Right, AngleDegrees.Right },
            { AngleDegrees.Full + AngleDegrees.Right + AcuteAngle, AngleDegrees.Right + AcuteAngle },
            { AngleDegrees.Full + AngleDegrees.Straight, AngleDegrees.Straight },

            { -AngleDegrees.Full, AngleDegrees.Zero },
            { -AcuteAngle, AngleDegrees.Full - AcuteAngle },
            { -AngleDegrees.Right, AngleDegrees.Full - AngleDegrees.Right },
            { -AngleDegrees.Straight, AngleDegrees.Straight },
            { -AngleDegrees.Straight - AngleDegrees.Right, AngleDegrees.Right },
        };

        [Theory]
        [MemberData(nameof(ReduceData))]
        public void Reduce_Should_Succeed(AngleDegrees angle, AngleDegrees expected)
        {
            // arrange

            // act
            var result = Angle.Reduce(angle);

            // assert
            result.Degrees.Should().BeApproximately(expected.Degrees, Math.Pow(10, 8));
        }

        public static TheoryData<AngleDegrees, Quadrant> QuadrantData => new TheoryData<AngleDegrees, Quadrant> {
            {AngleDegrees.Zero, Quadrant.First},
            {AcuteAngle, Quadrant.First},
            {AngleDegrees.Right, Quadrant.Second},
            {AngleDegrees.Right + AcuteAngle, Quadrant.Second},
            {AngleDegrees.Straight, Quadrant.Third},
            {AngleDegrees.Straight + AcuteAngle, Quadrant.Third},
            {AngleDegrees.Straight + AngleDegrees.Right, Quadrant.Fourth},
            {AngleDegrees.Straight + AngleDegrees.Right + AcuteAngle, Quadrant.Fourth},

            {AngleDegrees.Full, Quadrant.First},
            {AngleDegrees.Full + AcuteAngle, Quadrant.First},
            {AngleDegrees.Full + AngleDegrees.Right, Quadrant.Second},
            {AngleDegrees.Full + AngleDegrees.Right + AcuteAngle, Quadrant.Second},
            {AngleDegrees.Full + AngleDegrees.Straight, Quadrant.Third},
            {AngleDegrees.Full + AngleDegrees.Straight + AcuteAngle, Quadrant.Third},
            {AngleDegrees.Full + AngleDegrees.Straight + AngleDegrees.Right, Quadrant.Fourth},
            {AngleDegrees.Full + AngleDegrees.Straight + AngleDegrees.Right + AcuteAngle, Quadrant.Fourth},
        };

        [Theory]
        [MemberData(nameof(QuadrantData))]
        public void GetQuadrant_Should_Succeed(AngleDegrees angle, Quadrant expected)
        {
            // arrange

            // act
            var result = Angle.GetQuadrant(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, AngleDegrees> ReferencetData => new TheoryData<AngleDegrees, AngleDegrees> {
            {AngleDegrees.Zero, AngleDegrees.Zero},
            {AcuteAngle, AcuteAngle},
            {-AcuteAngle, AcuteAngle},
            {AngleDegrees.Right ,AngleDegrees.Right},
            {AngleDegrees.Right + AcuteAngle, AcuteAngle},
            {AngleDegrees.Straight, AngleDegrees.Zero},
            {AngleDegrees.Straight + AcuteAngle, AcuteAngle},
            {AngleDegrees.Straight + AngleDegrees.Right, AngleDegrees.Right},
            {AngleDegrees.Straight + AngleDegrees.Right + AcuteAngle, AcuteAngle},
            {AngleDegrees.Full, AngleDegrees.Zero},
        };

        [Theory]
        [MemberData(nameof(ReferencetData))]
        public void Reference_Should_Succeed(AngleDegrees angle, AngleDegrees expected)
        {
            // arrange

            // act
            var result = Angle.GetReference(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, bool> IsZeroData => new TheoryData<AngleDegrees, bool> {
            {AngleDegrees.Zero, true},
            {AcuteAngle, false},
            {AngleDegrees.Right, false},
            {AngleDegrees.Right + AcuteAngle, false},
            {AngleDegrees.Straight, false},
            {AngleDegrees.Straight + AngleDegrees.Right, false},
            {AngleDegrees.Full, true},

            {-AcuteAngle, false},
            {-AngleDegrees.Right, false},
            {-AngleDegrees.Right - AcuteAngle, false},
            {-AngleDegrees.Straight, false},
            {-AngleDegrees.Straight - AngleDegrees.Right, false},
            {-AngleDegrees.Full, true},
        };

        [Theory]
        [MemberData(nameof(IsZeroData))]
        public void IsZero_Should_Succeed(AngleDegrees angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsZero(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, bool> IsAcuteData => new TheoryData<AngleDegrees, bool> {
            {AngleDegrees.Zero, false},
            {AcuteAngle, true},
            {AngleDegrees.Right, false},
            {AngleDegrees.Right + AcuteAngle, false},
            {AngleDegrees.Straight, false},
            {AngleDegrees.Straight + AngleDegrees.Right, false},
            {AngleDegrees.Full, false},

            {-AcuteAngle, true},
            {-AngleDegrees.Right, false},
            {-AngleDegrees.Right - AcuteAngle, false},
            {-AngleDegrees.Straight, false},
            {-AngleDegrees.Straight - AngleDegrees.Right, false},
            {-AngleDegrees.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsAcuteData))]
        public void IsAcute_Should_Succeed(AngleDegrees angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsAcute(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, bool> IsRightData => new TheoryData<AngleDegrees, bool> {
            {AngleDegrees.Zero, false},
            {AcuteAngle, false},
            {AngleDegrees.Right, true},
            {AngleDegrees.Right + AcuteAngle, false},
            {AngleDegrees.Straight, false},
            {AngleDegrees.Straight + AngleDegrees.Right, false},
            {AngleDegrees.Full, false},

            {-AcuteAngle, false},
            {-AngleDegrees.Right, true},
            {-AngleDegrees.Right - AcuteAngle, false},
            {-AngleDegrees.Straight, false},
            {-AngleDegrees.Straight - AngleDegrees.Right, false},
            {-AngleDegrees.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsRightData))]
        public void IsRight_Should_Succeed(AngleDegrees angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsRight(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, bool> IsObtuseData => new TheoryData<AngleDegrees, bool> {
            {AngleDegrees.Zero, false},
            {AcuteAngle, false},
            {AngleDegrees.Right, false},
            {AngleDegrees.Right + AcuteAngle, true},
            {AngleDegrees.Straight, false},
            {AngleDegrees.Straight + AngleDegrees.Right, false},
            {AngleDegrees.Full, false},

            {-AcuteAngle, false},
            {-AngleDegrees.Right, false},
            {-AngleDegrees.Right - AcuteAngle, true},
            {-AngleDegrees.Straight, false},
            {-AngleDegrees.Straight - AngleDegrees.Right, false},
            {-AngleDegrees.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsObtuseData))]
        public void IsObtuse_Should_Succeed(AngleDegrees angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsObtuse(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, bool> IsStraightData => new TheoryData<AngleDegrees, bool> {
            {AngleDegrees.Zero, false},
            {AcuteAngle, false},
            {AngleDegrees.Right, false},
            {AngleDegrees.Right - AcuteAngle, false},
            {AngleDegrees.Straight, true},
            {AngleDegrees.Straight - AngleDegrees.Right, false},
            {AngleDegrees.Full, false},

            {-AcuteAngle, false},
            {-AngleDegrees.Right, false},
            {-AngleDegrees.Right - AcuteAngle, false},
            {-AngleDegrees.Straight, true},
            {-AngleDegrees.Straight - AngleDegrees.Right, false},
            {-AngleDegrees.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsStraightData))]
        public void IsStraight_Should_Succeed(AngleDegrees angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsStraight(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, bool> IsReflexData => new TheoryData<AngleDegrees, bool> {
            {AngleDegrees.Zero, false},
            {AcuteAngle, false},
            {AngleDegrees.Right, false},
            {AngleDegrees.Right + AcuteAngle, false},
            {AngleDegrees.Straight, false},
            {AngleDegrees.Straight + AngleDegrees.Right, true},
            {AngleDegrees.Full, false},

            {-AcuteAngle, false},
            {-AngleDegrees.Right, false},
            {-AngleDegrees.Right - AcuteAngle, false},
            {-AngleDegrees.Straight, false},
            {-AngleDegrees.Straight - AngleDegrees.Right, true},
            {-AngleDegrees.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsReflexData))]
        public void IsReflex_Should_Succeed(AngleDegrees angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsReflex(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, bool> IsObliqueData => new TheoryData<AngleDegrees, bool> {
            {AngleDegrees.Zero, false},
            {AcuteAngle, true},
            {AngleDegrees.Right, false},
            {AngleDegrees.Right + AcuteAngle, true},
            {AngleDegrees.Straight, false},
            {AngleDegrees.Straight + AngleDegrees.Right, false},
            {AngleDegrees.Full, false},

            {-AcuteAngle, true},
            {-AngleDegrees.Right, false},
            {-AngleDegrees.Right - AcuteAngle, true},
            {-AngleDegrees.Straight, false},
            {-AngleDegrees.Straight - AngleDegrees.Right, false},
            {-AngleDegrees.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsObliqueData))]
        public void IsOblique_Should_Succeed(AngleDegrees angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsOblique(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, AngleDegrees, double, AngleDegrees> LerpData => new TheoryData<AngleDegrees, AngleDegrees, double, AngleDegrees>
        {
            {AcuteAngle, AngleDegrees.Right + AcuteAngle, -0.5, AngleDegrees.Zero},
            {AcuteAngle, AngleDegrees.Right + AcuteAngle, 0.0, AcuteAngle},
            {AcuteAngle, AngleDegrees.Right + AcuteAngle, 0.5, AngleDegrees.Right},
            {AcuteAngle, AngleDegrees.Right + AcuteAngle, 1.0, AngleDegrees.Right + AcuteAngle},
            {AcuteAngle, AngleDegrees.Right + AcuteAngle, 1.5, AngleDegrees.Straight},

            {-AcuteAngle, -AngleDegrees.Right - AcuteAngle, -0.5, AngleDegrees.Zero},
            {-AcuteAngle, -AngleDegrees.Right - AcuteAngle, 0.0, -AcuteAngle},
            {-AcuteAngle, -AngleDegrees.Right - AcuteAngle, 0.5, -AngleDegrees.Right},
            {-AcuteAngle, -AngleDegrees.Right - AcuteAngle, 1.0, -AngleDegrees.Right - AcuteAngle},
            {-AcuteAngle, -AngleDegrees.Right - AcuteAngle, 1.5, -AngleDegrees.Straight},

            {AngleDegrees.Right + AcuteAngle, AcuteAngle, -0.5, AngleDegrees.Straight},
            {AngleDegrees.Right + AcuteAngle, AcuteAngle, 0.0, AngleDegrees.Right + AcuteAngle},
            {AngleDegrees.Right + AcuteAngle, AcuteAngle, 0.5, AngleDegrees.Right},
            {AngleDegrees.Right + AcuteAngle, AcuteAngle, 1.0, AcuteAngle},
            {AngleDegrees.Right + AcuteAngle, AcuteAngle, 1.5, AngleDegrees.Zero},
        };

        [Theory]
        [MemberData(nameof(LerpData))]
        public void Lerp_Should_Succeed(AngleDegrees a1, AngleDegrees a2, double t, AngleDegrees expected)
        {
            // arrange

            // act
            var result = Angle.Lerp(a1, a2, t);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, string> ToStringData => new TheoryData<AngleDegrees, string>
        {
            {AngleDegrees.Straight, "180"},
        };

        [Theory]
        [MemberData(nameof(ToStringData))]
        public void ToString_Should_Succeed(AngleDegrees angle, string expected)
        {
            // arrange
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            // act
            var result = angle.ToString();

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, string, string> ToStringFormatData => new TheoryData<AngleDegrees, string, string>
        {
            {AngleDegrees.Straight, "0.00", "180.00"},
        };

        [Theory]
        [MemberData(nameof(ToStringFormatData))]
        public void ToStringFormat_Should_Succeed(AngleDegrees angle, string format, string expected)
        {
            // arrange
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            // act
            var result = angle.ToString(format);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, string, CultureInfo, string> ToStringFormatCultureData => new TheoryData<AngleDegrees, string, CultureInfo, string>
        {
            {AngleDegrees.Straight, "0.00", new CultureInfo("pt-PT"), "180,00"},
        };

        [Theory]
        [MemberData(nameof(ToStringFormatCultureData))]
        public void ToStringFormatCulture_Should_Succeed(AngleDegrees angle, string format, CultureInfo culture, string expected)
        {
            // arrange

            // act
            var result = angle.ToString(format, culture);

            // assert
            result.Should().Be(expected);
        }

    }
}
