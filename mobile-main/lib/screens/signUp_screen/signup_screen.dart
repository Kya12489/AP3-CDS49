import 'package:flutter/material.dart';
import 'package:mobil_cds49/main.dart';
import 'package:mobil_cds49/screens/screen_login/log_user.dart';
import 'package:mobil_cds49/services/api/gestionUsr/usr_api.dart';
import 'package:mobil_cds49/widgets/datetimePicker.dart';

// Ecran de connexion pour les utilisateurs
class signUp extends StatefulWidget {
  const signUp({super.key});
  @override
  State<signUp> createState() => _signUpState();
}

class _signUpState extends State<signUp> {
  final TextEditingController emailController = TextEditingController();
  final TextEditingController passwordController = TextEditingController();
  final TextEditingController nomController = TextEditingController();
  final TextEditingController prenomController = TextEditingController();
  final TextEditingController dnController = TextEditingController();

  bool isPasswordVisible = false;

  // Méthode pour gérer la connexion de l'utilisateur
  void signUp() async {
    String nom = nomController.text;
    String prenom = prenomController.text;
    String dateNaissance = dnController.text;
    String email = emailController.text;
    String password = passwordController.text;

    try {
      if (email.isNotEmpty &&
          password.isNotEmpty &&
          nom.isNotEmpty &&
          prenom.isNotEmpty &&
          dateNaissance.isNotEmpty) {
        final result = await UsrApi().sign(
          nom,
          prenom,
          dateNaissance,
          email,
          password,
        );
        // Vérifie que le widget est toujours actif avant d'utiliser context (Bonne pratique pour éviter les erreurs de contexte)
        if (!mounted) return;

        if (result != null && result['status'] == "success") {
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text(
                'Inscription réussie ! Vous pouvez maintenant vous connecter.',
              ),
            ), // Affiche un message de succès
          );
          Navigator.pushReplacement(
            context,
            MaterialPageRoute(builder: (context) => LoginUtilisateur()),
          ); // Réouvre la page d'accueil pour forcer la mise à jour de l'état
        } else {
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text('Échec de l\'inscription : ${result?['message']}'),
            ),
          );
        }
      } else {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Veuillez remplir tous les champs')),
        );
      }
    } catch (e) {
      // Vous pouvez afficher une erreur ou la gérer ici
      ScaffoldMessenger.of(
        context,
      ).showSnackBar(SnackBar(content: Text('Une erreur est survenue : $e')));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Inscription')),
      body: Padding(
        padding: EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            TextField(
              controller: prenomController,
              decoration: InputDecoration(
                labelText: 'Prenom',
                prefixIcon: Icon(Icons.email),
                border: OutlineInputBorder(),
              ),
              keyboardType: TextInputType.name,
            ),
            SizedBox(height: 20),
            TextField(
              controller: nomController,
              decoration: InputDecoration(
                labelText: 'Nom',
                prefixIcon: Icon(Icons.email),
                border: OutlineInputBorder(),
              ),
              keyboardType: TextInputType.name,
            ),
            SizedBox(height: 20),
            // Champ de saisie pour l'email
            TextField(
              controller: emailController,
              decoration: InputDecoration(
                labelText: 'Email',
                prefixIcon: Icon(Icons.email),
                border: OutlineInputBorder(),
              ),
              keyboardType: TextInputType.emailAddress,
            ),
            SizedBox(height: 20),
            DateTimePicker(
              onDateSelected: (DateTime pickedDate) {
                setState(() {
                  dnController.text =
                      "${pickedDate.day}/${pickedDate.month}/${pickedDate.year}";
                });
              },
              initialDate: DateTime.now(),
              firstDate: DateTime(1900),
              lastDate: DateTime.now(),
            ),
            //champs de saisie pour la date de naissance
            SizedBox(height: 20),
            // Champ de saisie pour le mot de passe + icone pour afficher/masquer le mot de passe
            TextField(
              controller: passwordController,
              obscureText: !isPasswordVisible,
              decoration: InputDecoration(
                labelText: 'Mot de passe',
                prefixIcon: Icon(Icons.lock),
                border: OutlineInputBorder(),
                suffixIcon: IconButton(
                  icon: Icon(
                    isPasswordVisible ? Icons.visibility : Icons.visibility_off,
                  ),
                  onPressed: () {
                    setState(() {
                      isPasswordVisible = !isPasswordVisible;
                    });
                  },
                ),
              ),
            ),
            SizedBox(height: 20),
            ElevatedButton(onPressed: signUp, child: Text("S'inscrire")),
          ],
        ),
      ),
    );
  }
}
