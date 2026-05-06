import 'dart:convert';
import 'dart:io';
import 'dart:typed_data';

import 'package:file_picker/file_picker.dart';
import 'package:flutter_file_dialog/flutter_file_dialog.dart';
import 'package:http/http.dart' as http;
import 'package:mobil_cds49/models/documents.dart';

import 'package:mobil_cds49/services/api/config.dart';
import 'package:mobil_cds49/services/gestion_token/token.dart';
import 'package:path_provider/path_provider.dart';

class DocumentApi {
  Future<int> getDocumentInWaiting() async {
    try {
      final token = await GestionToken.getToken();
      final response = await http.post(
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
      final response = await http.post(
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

  Future<Map<String, dynamic>> uploadDocument(
    PlatformFile platformFile,
    int documentId,
  ) async {
    try {
      final token = await GestionToken.getToken();
      if (token == null || token.isEmpty) {
        return {'status': 'error', 'message': 'Non autorisé - Token manquant'};
      }

      Uint8List? bytes = platformFile.bytes;
      final String fileName = platformFile.name;

      if (bytes == null) {
        if (platformFile.path == null) {
          return {
            'status': 'error',
            'message': 'Impossible de lire le fichier',
          };
        }
        final file = File(platformFile.path!);
        bytes = await file.readAsBytes();
      }

      var request = http.MultipartRequest(
        'POST',
        Uri.parse('${AppConfig.apiBaseUrl}/api/documents/upload'),
      );

      request.headers.addAll({
        'Authorization': 'Bearer $token',
        'Accept': 'application/json',
      });

      request.files.add(
        http.MultipartFile.fromBytes('document', bytes, filename: fileName),
      );

      request.fields['document_id'] = documentId.toString();

      var streamedResponse = await request.send();
      var response = await http.Response.fromStream(streamedResponse);

      // ← Parser le body en JSON d'abord
      final responseBody = json.decode(response.body);

      if (response.statusCode == 200 || response.statusCode == 201) {
        return responseBody;
      } else {
        return {
          'status': 'error',
          'message': responseBody['message'] ?? 'Erreur ${response.statusCode}',
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

      final url = Uri.parse('${AppConfig.apiBaseUrl}/api/documents/download');

      // ← Envoyer en form-data pour que $_POST le reçoive
      final response = await http.post(
        url,
        headers: {'Authorization': 'Bearer $token'},
        body: {'document_id': documentId.toString()},
      );

      if (response.statusCode == 200) {
        String finalFileName = fileName;
        final contentDisposition = response.headers['content-disposition'];
        if (contentDisposition != null) {
          final regex = RegExp(r'filename="(.+)"');
          final match = regex.firstMatch(contentDisposition);
          if (match != null) {
            finalFileName = match.group(1)!;
          }
        }

        final tempDir = await getTemporaryDirectory();
        final tempFilePath = '${tempDir.path}/$finalFileName';
        await File(tempFilePath).writeAsBytes(response.bodyBytes);

        final finalPath = await FlutterFileDialog.saveFile(
          params: SaveFileDialogParams(
            sourceFilePath: tempFilePath,
            fileName: finalFileName,
          ),
        );

        if (await File(tempFilePath).exists()) {
          await File(tempFilePath).delete();
        }

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
        try {
          final errorBody = json.decode(response.body);
          return {
            'status': 'error',
            'message': errorBody['message'] ?? 'Erreur: ${response.statusCode}',
          };
        } catch (_) {
          return {
            'status': 'error',
            'message': 'Erreur: ${response.statusCode}',
          };
        }
      }
    } catch (e) {
      return {'status': 'error', 'message': 'Erreur: $e'};
    }
  }
}
