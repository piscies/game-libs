using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Piscies.Game
{
    public class CharacterGender
    {
        public enum Gender
        {
            Male = 1,
            Female = 2
        }

        private Gender genderValue;

        public CharacterGender(Gender gender)
        {
            genderValue = gender;
        }

        #region Comparison Methods
        public bool IsFemale()
        {
            if (genderValue == Gender.Female)
                return true;
            return false;
        }
        public bool IsMale()
        {
            if (genderValue == Gender.Male)
                return true;
            return false;
        }
        #endregion

        #region Pronouns
        /// <summary>
        /// his or her
        /// </summary>
        public string PosessivePronoum
        {
            get
            {
                if (genderValue == Gender.Male)
                    return "his";
                if (genderValue == Gender.Female)
                    return "her";
                return "";
            }
        }
        /// <summary>
        /// His or Her
        /// </summary>
        public string PosessivePronoumUpper
        {
            get
            {
                if (genderValue == Gender.Male)
                    return "His";
                if (genderValue == Gender.Female)
                    return "Her";
                return "";
            }
        }
        /// <summary>
        /// him or her
        /// </summary>
        public string ObjectivePronoum
        {
            get
            {
                if (genderValue == Gender.Male)
                    return "him";
                if (genderValue == Gender.Female)
                    return "her";
                return "";
            }
        }
        /// <summary>
        /// Him or Her
        /// </summary>
        public string ObjectivePronoumUpper
        {
            get
            {
                if (genderValue == Gender.Male)
                    return "Him";
                if (genderValue == Gender.Female)
                    return "Her";
                return "";
            }
        }
        /// <summary>
        /// he or she
        /// </summary>
        public string SubjectivePronoum
        {
            get
            {
                if (genderValue == Gender.Male)
                    return "he";
                if (genderValue == Gender.Female)
                    return "she";
                return "";
            }
        }
        /// <summary>
        /// He or She
        /// </summary>
        public string SubjectivePronoumUpper
        {
            get
            {
                if (genderValue == Gender.Male)
                    return "He";
                if (genderValue == Gender.Female)
                    return "She";
                return "";
            }
        }
        #endregion
    }
}
