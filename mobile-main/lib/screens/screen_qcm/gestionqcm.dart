import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:mobil_cds49/models/categorie.dart';
import 'package:mobil_cds49/screens/screen_qcm/affichageqcm.dart';
import 'package:mobil_cds49/services/api/gestionCategorie/categorie_api.dart';
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
   int? selectedCategory; // null = Random
   List<Categorie>? lesCategories;
   bool isLoading = true;
  
  Future<void> _LoadListeCategorie() async{
    final info = await CategorieApi.getListeCategories();
     setState(() {
       lesCategories = info;
       isLoading = false;
     });
  }

  // retourne le libellé (nom) de la catégorie sélectionnée
  String selectCategorie() {
    if (randomQuestion || selectedCategory == null) return "Random";
    if (lesCategories == null || lesCategories!.isEmpty) return "..";
    for (final cat in lesCategories!) {
      if (cat.idCategorie == selectedCategory) {
        return cat.libelleCategorie ?? "..";
      }
    }
    return "..";
  }

  int? selectCategorieId(){
    return selectedCategory;
  }
  // Change l'état de la variable randomQuestion et met à jour la catégorie sélectionnée
  void categorieRadom(int? catId) {
    setState(() {
      if (catId == null) {
        randomQuestion = true;
        selectedCategory = null;
      } else {
        randomQuestion = false;
        selectedCategory = catId;
      }
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
    // charger les catégories depuis l'API
    _LoadListeCategorie();
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
             
              // item "Random"
              CategorieQuestion(
                title: "Random",
                icon: FontAwesomeIcons.shuffle,
                onTap: (){ categorieRadom(null); },
                nameSelected: selectCategorie(),
              ),
              SizedBox(height: 24),

              GridView.count(
                  shrinkWrap: true,
                  physics: NeverScrollableScrollPhysics(),
                  crossAxisCount: 2,
                  // ajuster si nécessaire
                  children: [
                    if (isLoading)
                      Center(child: Text("Loading ..."))
                    else
                      ...lesCategories!.map((cat) => CategorieQuestion(
                            title: cat.libelleCategorie ?? "...",
                            icon: FontAwesomeIcons.accusoft,
                            onTap: () {
                              categorieRadom(cat.idCategorie);
                            },
                            nameSelected: selectCategorie(),
                          ))
                          .toList(),
                  ]
                
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
                      categorieQuestion: selectCategorieId()??0,
                      onNavigate: widget.onNavigate,
                    ),
                  );
                },
                child: Text("Commencer le QCM"),
              ),
            ]
              ),
            ]
          ),
        ),
    );
  }
}