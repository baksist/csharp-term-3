using System;

namespace pr_06
{
    public class ResearchTeam
    {
        private string _researchTheme;
        private string _organizationName;
        private int _registrationNumber;
        private TimeFrame _researchDuration;
        private Paper[] _publications;

        public ResearchTeam(string researchTheme, string organizationName, int registrationNumber,
            TimeFrame researchDuration)
        {
            _researchTheme = researchTheme;
            _organizationName = organizationName;
            _registrationNumber = registrationNumber;
            _researchDuration = researchDuration;
        }

        public ResearchTeam()
        {
            _researchTheme = "DefaultResearchTheme";
            _organizationName = "DefaultOrganizationName";
            _registrationNumber = 0;
            _researchDuration = TimeFrame.Year;
        }
        
        public string ResearchTheme
        {
            get => _researchTheme;
            set => _researchTheme = value;
        }

        public string OrganizationName
        {
            get => _organizationName;
            set => _organizationName = value;
        }

        public int RegistrationNumber
        {
            get => _registrationNumber;
            set => _registrationNumber = value;
        }

        public TimeFrame ResearchDuration
        {
            get => _researchDuration;
            set => _researchDuration = value;
        }

        public Paper[] Publications
        {
            get => _publications;
            set => _publications = value;
        }

        public Paper MostRecentPaper
        {
            get
            {
                if (Publications.Length == 0)
                    return null;
                else
                {
                    ref Paper output = ref Publications[0];
                    DateTime cmp = DateTime.UnixEpoch;
                    for (var i = 0; i < Publications.Length; i++)    
                    {
                        if (Publications[i].PublicationDate > cmp)
                        {
                            cmp = Publications[i].PublicationDate;
                            output = ref Publications[i];
                        }
                    }
                    return output;
                }
            }
        }
       public bool this[TimeFrame researchDuration] => _researchDuration == researchDuration;

       public void AddPapers(params Paper[] newPublications)
       {
           var newArray = new Paper[Publications.Length + newPublications.Length];
           for (var i = 0; i < Publications.Length; i++)
               newArray[i] = Publications[i];
           for (var i = 0; i < newPublications.Length; i++)
               newArray[Publications.Length + i] = newPublications[i];
           Publications = newArray;
       }

       public override string ToString()
       {
           string output = "";
           output += OrganizationName + '\n' + ResearchTheme + '\n' + RegistrationNumber + '\n' + ResearchDuration;
           foreach (var i in Publications)
           {
               output += '\n' + i.ToString();
           }

           return output;
       }

       public string ToShortString()
       {
           return ResearchTheme + ' ' + OrganizationName + ' ' + RegistrationNumber + ' ' + ResearchDuration;
       }
    }
}