import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:mobil_cds49/models/documents.dart';

import 'package:mobil_cds49/services/api/config.dart';
import 'package:mobil_cds49/services/gestion_token/token.dart';

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
}
