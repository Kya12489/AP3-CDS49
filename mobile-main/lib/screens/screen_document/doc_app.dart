import 'dart:io';
import 'package:flutter/material.dart';
import 'package:mobil_cds49/main.dart';
import 'package:mobil_cds49/models/documents.dart';
import 'package:mobil_cds49/services/api/config.dart';
import 'package:mobil_cds49/services/api/gestionDocument/documentsAPI.dart';
import 'package:mobil_cds49/widgets/app_bar.dart';
import 'package:mobil_cds49/widgets/upload.dart';
import 'package:open_file/open_file.dart';
import 'package:dio/dio.dart';
import 'package:path_provider/path_provider.dart';

class DocumentApp extends StatefulWidget {
  const DocumentApp({super.key});
  @override
  State<DocumentApp> createState() => _DocumentAppState();
}

class _DocumentAppState extends State<DocumentApp> {
  final List<Document> documents = [];
  Map<int, File?> selectedFiles = {}; // Un fichier par document
  Map<int, bool> isUploading = {}; // État de chargement par document

  @override
  void initState() {
    super.initState();
    DocumentApi().getDocuments().then((docs) {
      setState(() {
        documents.addAll(docs);
      });
    });
  }

  // Méthode pour télécharger et ouvrir un fichier depuis une URL
  Future<void> _downloadAndOpenFile(String url, String name) async {
    try {
      // Afficher un indicateur de chargement
      showDialog(
        context: context,
        barrierDismissible: false,
        builder: (context) => const Center(child: CircularProgressIndicator()),
      );

      // Extraire le nom du fichier depuis l'URL
      String fileName = url.split('/').last;

      // Créer une instance de Dio
      final dio = Dio();

      // Utiliser getTemporaryDirectory ou getApplicationDocumentsDirectory
      final Directory appDocDir = await getApplicationDocumentsDirectory();
      final String filePath = '${appDocDir.path}/$name-$fileName';

      // Télécharger le fichier depuis l'URL complète
      await dio.download(
        url,
        filePath,
        onReceiveProgress: (received, total) {
          if (total != -1) {
            print(
              'Téléchargement : ${(received / total * 100).toStringAsFixed(0)}%',
            );
          }
        },
      );

      // Fermer le loader
      Navigator.pop(context);

      // Ouvrir le fichier
      await OpenFile.open(filePath);
    } catch (e) {
      Navigator.pop(context);
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Erreur lors du téléchargement : $e'),
          backgroundColor: Colors.red,
        ),
      );
    }
  }

  // Méthode pour uploader le document
  Future<void> _uploadDocument(Document doc, File file) async {
    setState(() {
      isUploading[doc.id] = true;
    });
    try {
      final result = await DocumentApi().uploadDocument(file, doc.id);
      if (result['status'] == 'success') {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(
            content: Text('Document envoyé avec succès !'),
            backgroundColor: Colors.green,
          ),
        );
        // Rafraîchir la liste des documents
        final updatedDocs = await DocumentApi().getDocuments();
        setState(() {
          documents.clear();
          documents.addAll(updatedDocs);
          selectedFiles[doc.id] = null;
          Navigator.pushReplacement(
            context,
            MaterialPageRoute(builder: (context) => const DocumentApp()),
          );
        });
      } else {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
            content: Text('Erreur: ${result['message']}'),
            backgroundColor: Colors.red,
          ),
        );
      }
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Erreur: $e'), backgroundColor: Colors.red),
      );
    } finally {
      setState(() {
        isUploading[doc.id] = false;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBarPrincipal(
        actions: [
          IconButton(
            icon: const Icon(Icons.arrow_back),
            onPressed: () {
              Navigator.pushReplacement(
                context,
                MaterialPageRoute(
                  builder: (context) =>
                      const MyHomePage(title: 'CDS 49', currentIndex: 2),
                ),
              );
            },
          ),
          const Text("Mes Documents"),
        ],
      ),
      body: Center(
        child: ListView(
          children: <Widget>[
            for (var doc in documents)
              Card(
                margin: const EdgeInsets.all(12),
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: <Widget>[
                    ListTile(
                      leading: const Icon(Icons.insert_drive_file),
                      title: Text(doc.type),
                      subtitle: Text(
                        'Statut: ${doc.statut}',
                        style: doc.idStatut == 1 || doc.idStatut == 2
                            ? const TextStyle(
                                color: Colors.orange,
                                fontWeight: FontWeight.bold,
                              )
                            : doc.idStatut == 3
                            ? const TextStyle(
                                color: Colors.green,
                                fontWeight: FontWeight.bold,
                              )
                            : const TextStyle(
                                color: Colors.red,
                                fontWeight: FontWeight.bold,
                              ),
                      ),
                    ),
                    // Afficher le fichier sélectionné
                    if (selectedFiles[doc.id] != null) ...[
                      Container(
                        margin: const EdgeInsets.only(
                          bottom: 8,
                          left: 12,
                          right: 12,
                        ),
                        padding: const EdgeInsets.all(12),
                        decoration: BoxDecoration(
                          color: Colors.grey.shade100,
                          borderRadius: BorderRadius.circular(10),
                          border: Border.all(color: Colors.grey.shade300),
                        ),
                        child: Row(
                          children: [
                            Container(
                              width: 50,
                              height: 50,
                              decoration: BoxDecoration(
                                color: _isPdf(selectedFiles[doc.id]!)
                                    ? Colors.red.shade50
                                    : Colors.blue.shade50,
                                borderRadius: BorderRadius.circular(8),
                              ),
                              child: _isPdf(selectedFiles[doc.id]!)
                                  ? const Icon(
                                      Icons.picture_as_pdf,
                                      color: Colors.red,
                                      size: 30,
                                    )
                                  : ClipRRect(
                                      borderRadius: BorderRadius.circular(8),
                                      child: Image.file(
                                        selectedFiles[doc.id]!,
                                        fit: BoxFit.cover,
                                      ),
                                    ),
                            ),
                            const SizedBox(width: 12),
                            Expanded(
                              child: Text(
                                selectedFiles[doc.id]!.path.split('/').last,
                                overflow: TextOverflow.ellipsis,
                                style: const TextStyle(fontSize: 12),
                              ),
                            ),
                            IconButton(
                              icon: const Icon(Icons.close, size: 20),
                              onPressed: () {
                                setState(() {
                                  selectedFiles[doc.id] = null;
                                });
                              },
                              color: Colors.red,
                            ),
                          ],
                        ),
                      ),
                    ],
                    // Bouton télécharger ou message
                    if (doc.lien != null && doc.lien!.isNotEmpty)
                      TextButton(
                        child: const Text("Télécharger le document"),
                        onPressed: () async {
                          // Construire l'URL complète
                          String url =
                              "${AppConfig.apiBaseUrl}/documents/${doc.lien}";
                          await _downloadAndOpenFile(url, doc.type!);
                        },
                      )
                    else
                      const Padding(
                        padding: EdgeInsets.all(8.0),
                        child: Text("Fichier non téléversé"),
                      ),
                    // Bouton pour ajouter un fichier
                    Padding(
                      padding: const EdgeInsets.all(12),
                      child: FilePickerButton(
                        onFilesSelected: (file) {
                          setState(() {
                            selectedFiles[doc.id] = file;
                          });
                        },
                      ),
                    ),
                    // Bouton d'envoi
                    if (selectedFiles[doc.id] != null)
                      Padding(
                        padding: const EdgeInsets.all(12),
                        child: isUploading[doc.id] == true
                            ? const CircularProgressIndicator()
                            : ElevatedButton.icon(
                                onPressed: () {
                                  _uploadDocument(doc, selectedFiles[doc.id]!);
                                },
                                icon: const Icon(Icons.cloud_upload),
                                label: const Text('Envoyer le document'),
                                style: ElevatedButton.styleFrom(
                                  backgroundColor: Colors.green,
                                  foregroundColor: Colors.white,
                                  padding: const EdgeInsets.symmetric(
                                    horizontal: 24,
                                    vertical: 12,
                                  ),
                                ),
                              ),
                      ),
                  ],
                ),
              ),
          ],
        ),
      ),
    );
  }

  bool _isPdf(File file) {
    return file.path.toLowerCase().endsWith('.pdf');
  }
}
