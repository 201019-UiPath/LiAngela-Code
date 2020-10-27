using System;
using Xunit;
using HerosLib;

namespace HerosTest
{
    public class HeroTest
    {
        // arrange artifacts
        Hero testHero = new Hero();

        [Theory]
        [InlineData("Power to do unit testing")]
        [InlineData("Flying")]
        [InlineData("Laser eyes")]
        public void AddSuperPowerShouldAddSuperPower(string superPower)
        {
            // act
            testHero.AddSuperPower(superPower);

            // assert
            Assert.Equal(superPower, Hero.superPowers.Peek());
        }

        // arrange
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void AddSuperPowerShouldThrowArgumentException(string superPower)
        {
            // exceptions in unit tests => act and assert are in the same line
            Assert.Throws<ArgumentException>(() => testHero.AddSuperPower(superPower));
        }
    }
}
