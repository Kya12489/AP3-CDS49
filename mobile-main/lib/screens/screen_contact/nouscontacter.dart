import 'package:flutter/material.dart';

// Ecran de paramètres de l'application
class ContactApp extends StatefulWidget {
  const ContactApp({super.key});

  @override
  State<ContactApp> createState() => _ParamAppState();
}
Card createCard(List<Widget> content){
  Card newCard = Card(
    margin: EdgeInsets.all(12),
    child: 
    Padding(
      padding: EdgeInsets.all(16),
      child: Column(
        spacing: 20,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: content
      )
    )
  );
  return newCard;
}
Row addContainer(IconData icon,String title,String content){
  double containerWidth = 105;
  Row newRow = Row(
    spacing: 5,
    children: [
      Icon(icon),
      Row(
        
        spacing: 25,
        children: [
          Container(
            width: containerWidth,
            child: Text(title),
          ),
          Container(
            child: Text(content),
          )
        ],
      )
    ],
  );
  return newRow;
}
class _ParamAppState extends State<ContactApp> {
  @override
  void initState() {
    super.initState();
  }
  @override

  Widget build(BuildContext context) {
     return SizedBox(
      width: double.infinity,
      height: double.infinity,
      child: Column(
        children: <Widget>[          
          Expanded(
            child: ListView(
              children: [ 
                createCard(<Widget>[
                  Text("Nos coordonées"), 
                  addContainer(Icons.place, "Adresse :", "2 Rue Adrien Recouvreur, 49100, Angers France"),
                  addContainer(Icons.phone, "Téléphone :", "02 XX XX XX XX"),
                  addContainer(Icons.mail, "Adresse e-mail :", "contact@cds49.fr"),
                  addContainer(Icons.web  , "Site web :", "http://frontap3.dombtsig.local/")
                ]),
                createCard(<Widget>[
                  Text("Nos horraires"), 
                  addContainer(Icons.alarm_on_sharp, "Adresse :", "2 Rue Adrien Recouvreur, 49100, Angers France"),
                  addContainer(Icons.phone, "Téléphone :", "02 XX XX XX XX"),
                  addContainer(Icons.mail, "Adresse e-mail :", "contact@cds49.fr"),
                  addContainer(Icons.web  , "Site web :", "http://frontap3.dombtsig.local/")
                ])
                       
              ],
            ),
          ),
          
        ],
      ),
    );
  }
}