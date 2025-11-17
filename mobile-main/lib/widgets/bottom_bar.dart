import 'package:flutter/material.dart';
import 'package:mobil_cds49/services/gestion_token/token.dart';

class BottomNavbar extends StatelessWidget {
  final int currentIndex;
  final int nbNotif;
  final Function(int) onDestinationSelected;

  const BottomNavbar({
    super.key,
    required this.currentIndex,
    required this.onDestinationSelected,
    this.nbNotif = 0,
  });
  // Empeche l'utilisateur de naviguer vers le QCM s'il n'est pas connecté
  Future<void> _verifQCM(BuildContext context, int index) async {
    if (index == 1) {
      final autorise = await GestionToken.isLogged();
      if (!autorise && context.mounted) {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(
            content: Text('Veuillez vous connecter pour accéder au QCM'),
          ),
        );
        return;
      }
    } else if (index == 4) {
      final autorise = await GestionToken.isLogged();
      if (!autorise && context.mounted) {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(
            content: Text(
              'Veuillez vous connecter pour accéder à l\'historique des scores',
            ),
          ),
        );
        return;
      }
    }
    onDestinationSelected(index);
  }

  @override
  Widget build(BuildContext context) {
    // Construction de la barre de navigation
    return NavigationBar(
      selectedIndex: currentIndex,
      onDestinationSelected: (index) => _verifQCM(context, index),
      labelBehavior: NavigationDestinationLabelBehavior.onlyShowSelected,
      destinations: [
        NavigationDestination(
          selectedIcon: Icon(Icons.home),
          icon: Icon(Icons.home_outlined),
          label: 'Acceuil',
        ),
        NavigationDestination(
          selectedIcon: Icon(Icons.question_mark),
          icon: Icon(Icons.question_mark_outlined),
          label: 'QCM',
        ),
        NavigationDestination(
          selectedIcon: nbNotif == 0
              ? Icon(Icons.settings_outlined)
              : SizedBox(
                  width: 40,
                  height: 30,
                  child: Stack(
                    children: [
                      Positioned(
                        top: 0,
                        left: 0,
                        right: 0,
                        bottom: 0,
                        child: Icon(Icons.settings_outlined),
                      ),
                      Positioned(
                        top: 0,
                        right: 0,
                        child: CircleAvatar(
                          radius: 8,
                          backgroundColor: Colors.red,
                          child: Text(
                            "$nbNotif", // Remplacez par le nombre réel de notifications
                            style: TextStyle(color: Colors.white, fontSize: 12),
                          ),
                        ),
                      ),
                    ],
                  ),

                  //affiche l'icon et un cercle rouge avec le nombre de notifications non lues
                ),
          icon: SizedBox(
            width: 40,
            height: 30,
            child: nbNotif == 0
                ? Icon(Icons.settings_outlined)
                : Stack(
                    children: [
                      Positioned(
                        top: 0,
                        left: 0,
                        right: 0,
                        bottom: 0,
                        child: Icon(Icons.settings_outlined),
                      ),
                      Positioned(
                        top: 0,
                        right: 0,
                        child: CircleAvatar(
                          radius: 8,
                          backgroundColor: Colors.red,
                          child: Text(
                            "$nbNotif", // Remplacez par le nombre réel de notifications
                            style: TextStyle(color: Colors.white, fontSize: 12),
                          ),
                        ),
                      ),
                    ],
                  ),

            //affiche l'icon et un cercle rouge avec le nombre de notifications non lues
          ),
          label: 'Paramètres',
        ),
        NavigationDestination(
          selectedIcon: Icon(Icons.mail),
          icon: Icon(Icons.mail_outline),
          label: 'Nous contacter',
        ),
        NavigationDestination(
          selectedIcon: Icon(Icons.score),
          icon: Icon(Icons.score_outlined),
          label: 'Historique des scores',
        ),
      ],
    );
  }
}
