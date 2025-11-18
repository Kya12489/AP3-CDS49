import 'dart:convert';
import 'dart:io';

import 'package:flutter_file_dialog/flutter_file_dialog.dart';
import 'package:http/http.dart' as http;
import 'package:mobil_cds49/models/documents.dart';

import 'package:mobil_cds49/services/api/config.dart';
import 'package:mobil_cds49/services/gestion_token/token.dart';
import 'package:path_provider/path_provider.dart';
import 'package:permission_handler/permission_handler.dart';

class DocumentApi {
  Future<int> getDocumentInWaiting() async {
    try {
      final token = await GestionToken.getToken();
      final response = await http.get(
        Uri.parse('${AppConfig.apiBaseUrl}/api/documents/waiting'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization': 'Bearer $token',
        },
      );
      final data = jsonDecode(response.body);
      if (data["status"] == "success") {
        return data["data"]["nbNotif"] ?? 0;
      } else {
        return 0;
      }
    } catch (e) {
      return 0;
    }
  }

  Future<List<Document>> getDocuments() async {
    try {
      final token = await GestionToken.getToken();
      final response = await http.get(
        Uri.parse('${AppConfig.apiBaseUrl}/api/documents'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization': 'Bearer $token',
        },
      );
      final data = jsonDecode(response.body);
      if (data["status"] == "success") {
        List<Document> documents = (data["data"]["documents"] as List)
            .map((docJson) => Document.fromJson(docJson))
            .toList();
        return documents;
      } else {
        return [];
      }
    } catch (e) {
      return [];
    }
  }

  Future<Map<String, dynamic>> uploadDocument(File file, int documentId) async {
    try {
      final token = await GestionToken.getToken();

      if (token == null || token.isEmpty) {
        return {'status': 'error', 'message': 'Non autorisé - Token manquant'};
      }

      // Créer une requête multipart
      var request = http.MultipartRequest(
        'POST',
        Uri.parse('${AppConfig.apiBaseUrl}/api/documents/upload'),
      );

      // Ajouter les headers
      request.headers.addAll({
        'Authorization': 'Bearer $token',
        'Accept': 'application/json',
      });

      // Ajouter le fichier
      var fileStream = http.ByteStream(file.openRead());
      var fileLength = await file.length();
      var fileName = file.path.split('/').last;

      var multipartFile = http.MultipartFile(
        'document', // Nom du champ attendu par l'API
        fileStream,
        fileLength,
        filename: fileName,
      );

      request.files.add(multipartFile);

      // Ajouter d'autres champs si nécessaire
      request.fields['document_id'] = documentId.toString();

      // Envoyer la requête
      var streamedResponse = await request.send();

      // Récupérer la réponse
      var response = await http.Response.fromStream(streamedResponse);

      if (response.statusCode == 200 || response.statusCode == 201) {
        return json.decode(response.body);
      } else {
        return {
          'status': 'error',
          'message': 'Erreur lors de l\'envoi: ${response.statusCode}',
          'details': response.body,
        };
      }
    } catch (e) {
      return {'status': 'error', 'message': 'Erreur réseau: $e'};
    }
  }

  static Future<Map<String, dynamic>> downloadDocument(
    int documentId,
    String fileName,
  ) async {
    try {
      final token = await GestionToken.getToken();

      if (token == null || token.isEmpty) {
        return {'status': 'error', 'message': 'Non autorisé - Token manquant'};
      }

      final url = Uri.parse(
        '${AppConfig.apiBaseUrl}/api/documents/download?document_id=$documentId',
      );

      final response = await http.get(
        url,
        headers: {'Authorization': 'Bearer $token'},
      );

      if (response.statusCode == 200) {
        // Extraire le nom du fichier
        String finalFileName = fileName;
        final contentDisposition = response.headers['content-disposition'];
        if (contentDisposition != null) {
          final regex = RegExp(r'filename="(.+)"');
          final match = regex.firstMatch(contentDisposition);
          if (match != null) {
            finalFileName = match.group(1)!;
          }
        }

        // Créer un fichier temporaire
        final tempDir = await getTemporaryDirectory();
        final tempFilePath = '${tempDir.path}/$finalFileName';
        await File(tempFilePath).writeAsBytes(response.bodyBytes);

        // Sauvegarder automatiquement dans Téléchargements
        final finalPath = await FlutterFileDialog.saveFile(
          params: SaveFileDialogParams(
            sourceFilePath: tempFilePath,
            fileName: finalFileName,
          ),
        );

        // Nettoyer
        await File(tempFilePath).delete();

        if (finalPath != null) {
          return {
            'status': 'success',
            'message': 'Document enregistré dans Téléchargements',
            'file_path': finalPath,
          };
        } else {
          return {'status': 'error', 'message': 'Téléchargement annulé'};
        }
      } else {
        return {'status': 'error', 'message': 'Erreur: ${response.statusCode}'};
      }
    } catch (e) {
      return {'status': 'error', 'message': 'Erreur: $e'};
    }
  }
}
