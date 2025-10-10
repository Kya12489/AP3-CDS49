import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:mobil_cds49/screens/screen_qcm/affichageqcm.dart';
import 'package:mobil_cds49/widgets/categorieQuestion.dart';


// Ecran permettant de sélectionner le nombre de questions et la catégorie pour un QCM
class CodeQCM extends StatefulWidget {
  final void Function(Widget)? onNavigate;
  const CodeQCM({super.key, this.onNavigate});

  @override
  State<CodeQCM> createState() => _CodeQCMState();
}

class _CodeQCMState extends State<CodeQCM> {
   // Nombre de questions par défault 
   int selectedNumber = 40;
   bool randomQuestion = true;
   int idCatSelected = 0;
   String selectedCategory = "random";
  
  // Sélectionne la catégorie de questions
  String selectCategorie() {
    return selectedCategory;
  }

  // Change l'état de la variable randomQuestion et met à jour la catégorie sélectionnée
  void categorieRadom(String cat) {
    setState(() {
      randomQuestion = !randomQuestion;
      selectedCategory = cat;
    });
  }
  
  // Liste des valeurs pour la dropdown de sélection du nombre de questions
  final dropdownValues = [0, 10, 20, 30, 40];
  late final List<DropdownMenuItem<int>> dropdownItems;

  // Initialise la liste des dropdown items à partir des valeurs définies
  @override
  void initState() {
    super.initState();
    dropdownItems = dropdownValues
        .map((value) => DropdownMenuItem<int>(
              value: value,
              child: Text('$value'),
            ))
        .toList();   
  }
  
  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      height: double.infinity,
      child: Center(
          child: ListView(
            children: [
              Column(
                mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                'Chevrollier Drivins School',
                style: TextStyle(
                  fontSize: 22,                  
                ),
              ),
              // Gestion du nombre de questions 
              Card(
                margin: EdgeInsets.all(16),
                child: Padding(
                  padding: EdgeInsets.all(16),
                  child: Column(
                   children: [ 
                    Text(
                      'Nombre de questions',
                      style: TextStyle(
                        fontSize: 18,                  
                      ),
                    ),
                     DropdownButton<int>(
                      value: selectedNumber,
                      items: dropdownItems,
                      // Affiche la valeur selectionnée par l'utilisateur
                      onChanged: (value) {
                        setState(() {
                          selectedNumber = value!;
                        });
                      },
                      isExpanded: true,),
                    ],
                  ),
                ),
              ),              
             // Gestion de la catégorie de questions
              SizedBox(height: 64),
             
                  CategorieQuestion(
                title: "Random",
                icon: FontAwesomeIcons.shuffle,
                onTap: (){categorieRadom("Random");},
                nameSelected: selectedCategory,
              ),
              SizedBox(height: 24),
              CategorieQuestion(
                title: "Test1",
                icon: FontAwesomeIcons.shuffle,
                onTap: (){categorieRadom("Test1");},
                nameSelected: selectedCategory,
              ),
              SizedBox(height: 24),
              CategorieQuestion(
                title: "Test2",
                icon: FontAwesomeIcons.accusoft,
                onTap: (){categorieRadom("Test2");},
                nameSelected: selectedCategory,
              ),
              
              
              
               
              
              //Espace entre les éléments
              SizedBox(height: 24),
              SizedBox(height: 24),
              SizedBox(height: 24),
              // Bouton pour valider la sélection et naviguer vers l'écran de QCM
              ElevatedButton(
                onPressed: () {
                  widget.onNavigate?.call(
                    AffichageQCM(
                      key: UniqueKey(),
                      nbQuestions: selectedNumber,
                      categorieQuestion: selectCategorie(),
                      onNavigate: widget.onNavigate,
                    ),
                  );
                },
                child: Text('Valider'),
              ),
            ]
              ),
            ]
          ),
        ),
    );
  }
}