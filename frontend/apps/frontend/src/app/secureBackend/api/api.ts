export * from './auth.service';
import { AuthService } from './auth.service';
export * from './pw.service';
import { PwService } from './pw.service';
export * from './user.service';
import { UserService } from './user.service';
export * from './webUntis.service';
import { WebUntisService } from './webUntis.service';
export const APIS = [AuthService, PwService, UserService, WebUntisService];
