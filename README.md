# Artikler
Web API til at oprette, liste, hente og søge i artikler.

# Open API
Dokumentation er bedst i levende form, hvorfor jeg benytter en swagger side til at vise hvordan man kab benytte API'et, når det først kører. Indtil videre er følgende planlagt:

|HTTP|Handling|Parametre|Resultat|
|----|--------|---------|--------|
|GET|List|int skip, int take|Liste af artikelhoveder (uden indhold), sorteret efter årstal, forfatter, og overskrift. Parameteren "skip" springer over det angivne antal artikler, og "take" begrænser antallet af artikler i resultatsættet -- hvilket man i en front-end app kan benytte til at bladre mellem flere sider af resultater|
|GET|Get|int id|Hent pågældende artikel, inklusiv indhold.|
|POST|Create|int year, string author, string title, string content|Opret en ny artikel med leverede input.|
|POST|Update|Artikel artikel|Ret en given artikel med leverede input.|
|GET|Search|string query, int skip, int take|Søger i artikler forfatter, overskrift og indhold efter teksten i query.|

