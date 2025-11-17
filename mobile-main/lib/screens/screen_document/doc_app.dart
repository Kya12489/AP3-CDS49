import 'package:flutter/material.dart';
import 'package:mobil_cds49/main.dart';
import 'package:mobil_cds49/models/documents.dart';
import 'package:mobil_cds49/services/api/gestionDocument/documentsAPI.dart';
import 'package:mobil_cds49/widgets/app_bar.dart';

class DocumentApp extends StatefulWidget {
  const DocumentApp({super.key});

  @override
  State<DocumentApp> createState() => _DocumentAppState();
}

class _DocumentAppState extends State<DocumentApp> {
  final List<Document> documents = [];
  @override
  void initState() {
    super.initState();
    DocumentApi().getDocuments().then((docs) {
      setState(() {
        documents.addAll(docs);
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBarPrincipal(
        actions: [
          IconButton(
            icon: Icon(Icons.arrow_back),
            onPressed: () {
              setState(() {
                Navigator.pushReplacement(
                  context,
                  MaterialPageRoute(
                    builder: (context) =>
                        MyHomePage(title: 'CDS 49', currentIndex: 2),
                  ),
                );
              });
            },
          ),
          Text("Mes Documents"),
        ],
      ),
      body: Center(
        child: ListView(
          children: <Widget>[
            for (var doc in documents)
              Card(
                margin: EdgeInsets.all(12),
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: <Widget>[
                    ListTile(
                      leading: Icon(Icons.insert_drive_file),
                      title: Text(doc.type),
                      subtitle: Text(
                        'Statut: ${doc.statut}',
                        style: doc.idStatut == (1 ?? 2)
                            ? TextStyle(
                                color: Colors.orange,
                                fontWeight: FontWeight.bold,
                              )
                            : doc.idStatut == 3
                            ? TextStyle(
                                color: Colors.green,
                                fontWeight: FontWeight.bold,
                              )
                            : TextStyle(
                                color: Colors.red,
                                fontWeight: FontWeight.bold,
                              ),
                      ),
                    ),
                    doc.lien != ""
                        ? TextButton(
                            child: Text("Télécharger le document"),
                            onPressed: () {},
                          )
                        : Text("Fichier non téléversé"),
                    ElevatedButton(
                      onPressed: () {
                        // Action à effectuer lors du clic sur le bouton
                      },
                      child: Text('Transférer un nouveau document'),
                    ),
                  ],
                ),
              ),
          ],
        ),
      ),
    );
  }
}
