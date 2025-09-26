import 'package:flutter/material.dart';
import 'package:mobil_cds49/widgets/simple_Card.dart';
import 'package:url_launcher/url_launcher.dart';

// Ecran de paramètres de l'application
class ContactApp extends StatefulWidget {
  const ContactApp({super.key});

  @override
  State<ContactApp> createState() => _ParamAppState();
}

Card createCard(List<Widget> content) {
  Card newCard = Card(
      child: Column(
        spacing: 20,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: content,
      ),
    
  );
  return newCard;
}

Row addContainer(
  String title,
  String content, {
  IconData? icon,
  bool isBtn = false,
  VoidCallback? onBtnPressed
}) {
  Row newRow = Row(
    spacing: 5,
    children: [
      if (icon != null) Icon(icon),
      Row(
        spacing: 25,
        children: [
          Container(child: Text(title)),
          Container(child: isBtn?TextButton(onPressed: onBtnPressed, child: Text(content)):Text(content)),
        ],
      ),
    ],
  );
  return newRow;
}

class _ParamAppState extends State<ContactApp> {
  String phoneNb = "07 61 97 03 31";
  @override
  void initState() {
    super.initState();
  }

  void _launchDialer()  {
    final Uri launchUri = Uri(scheme: 'tel', path: phoneNb);
    try{
      launchUrl(launchUri);
    }on Exception catch(err){
      throw Exception("Impossible de lancer le dialect : $err");
    }
    Navigator.pop(context);
  }

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      height: double.infinity,
      child: ListView(
        children: <Widget>[
          Padding(
            
            padding: EdgeInsetsGeometry.all(16),
            child: Column(
              
              children: [
                Text(
                  "L'auto-école Chevrollier Driving School 49 (CDS 49) vous accompagne dans l'apprentissage de la conduite.",
                  textAlign: TextAlign.center ,
                  style: TextStyle(fontSize: 20,fontWeight: FontWeight.bold),
                ),
                
              ],
            ),
          ),
          CardPrincipal(
            child: Column(
              children: <Widget>[
                Text("Nos coordonées"),
            addContainer(
              icon: Icons.place,

              "Adresse :",
              "2 Rue Adrien Recouvreur\n49100, Angers France",
            ),

            addContainer("Téléphone",
            phoneNb ,
            icon: Icons.phone,
            onBtnPressed:  (){
              showDialog(
                context: context, 
                builder: (BuildContext context)=>Dialog(
                  child: Padding(
                  padding: EdgeInsetsGeometry.all(16),
                  child: Column(
                    
                    mainAxisSize: MainAxisSize.min,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      
                      Text("Voulez-vous appelez se numéro de téléphone : $phoneNb ?"),
                      Row(
                        mainAxisSize: MainAxisSize.min,
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                        TextButton(onPressed: _launchDialer, child: Text("Appeller")),
                        TextButton(onPressed: (){
                          Navigator.pop(context);
                        }, 
                        child: Text("Annuler"))
                      ],)
                    ],
                  ),)
                ));
            }
            ,isBtn: true),
            
            addContainer(
              icon: Icons.mail,
              "Adresse e-mail :",
              "contact@cds49.fr",
            ),
            addContainer(
              icon: Icons.web,
              "Site web :",
              "http://frontap3.dombtsig.local/",
            ),
              ],
            )

          ),
          createCard(<Widget>[
            
          ]),
          
          createCard(<Widget>[
            Text("Nos horraires"),
            addContainer(
              icon: Icons.alarm_on_sharp,
              "Du lundi au vendredi :",
              "",
            ),
            Text("08:00 - 12:00 "),
            Text("14:00 - 18:00 \n"),
          ]),
        ],
      ),
    );
  }
}
