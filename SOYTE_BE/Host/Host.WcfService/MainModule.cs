using Autofac;
using Business.Services;
using Business.Services.Contracts;
using Data.Core.Repositories;
using Data.Core.Repositories.Interfaces;
using log4net;

namespace Host.WcfService
{
    public class MainModule
    {
        public static IContainer BuildContainer()
        {
            log4net.Config.XmlConfigurator.Configure();
            var builder = new ContainerBuilder();

            // register services
            builder.RegisterType<ThuTucHanhChinhService>().As<IThuTucHanhChinhService>();
            builder.RegisterType<PhanAnhKienNghiService>().As<IPhanAnhKienNghiService>();
            
            builder.RegisterType<QuanTriService>().As<IQuanTriService>();
            builder.RegisterType<MotCuaService>().As<IMotCuaService>();
            builder.RegisterType<NganhYService>().As<INganhYService>();
            builder.RegisterType<DBMasterService>().As<IDBMasterService>();
            builder.RegisterType<NganhDuocService>().As<INganhDuocService>();
            builder.RegisterType<BaoCaoThongKeService>().As<IBaoCaoThongKeService>();
            builder.RegisterType<HoSoService>().As<IHoSoService>();
            // register repositories & log4net
            builder.Register(log => LogManager.GetLogger(typeof(MainModule))).SingleInstance();

            builder.RegisterType<DuongDiQuyTrinhRepository>().As<IDuongDiQuyTrinhRepository>();
            builder.RegisterType<ThuTucHanhChinhBoRepository>().As<IThuTucHanhChinhBoRepository>();
            builder.RegisterType<LinhVucRepository>().As<ILinhVucRepository>();
            builder.RegisterType<ParameterRepository>().As<IParameterRepository>();
            builder.RegisterType<DMCapDonViRepository>().As<IDMCapDonViRepository>();
            builder.RegisterType<ThuTucHanhChinhRepository>().As<IThuTucHanhChinhRepository>();
            builder.RegisterType<TTHCDonViMappingRepository>().As<ITTHCDonViMappingRepository>();
            builder.RegisterType<DMDonViRepository>().As<IDMDonViRepository>();
			builder.RegisterType<DMHoSoKemTheoRepository>().As<IDMHoSoKemTheoRepository>();
            builder.RegisterType<HoSoTiepNhanRepository>().As<IHoSoTiepNhanRepository>();
            builder.RegisterType<HoSoTheoDoiRepository>().As<IHoSoTheoDoiRepository>();
            builder.RegisterType<WorkListRepository>().As<IWorkListRepository>();
            builder.RegisterType<QuaTrinhXuLyRepository>().As<IQuaTrinhXuLyRepository>();
            builder.RegisterType<YeuCauBoSungRepository>().As<IYeuCauBoSungRepository>();
            builder.RegisterType<TamNgungThamDinhRepository>().As<ITamNgungThamDinhRepository>();
            builder.RegisterType<KhongGiaiQuyetRepository>().As<IKhongGiaiQuyetRepository>();
            builder.RegisterType<KhongPheDuyetRepository>().As<IKhongPheDuyetRepository>();
            builder.RegisterType<QuyTrinhRepository>().As<IQuyTrinhRepository>();
            builder.RegisterType<ChungChiHanhNgheYRepository>().As<IChungChiHanhNgheYRepository>();
            builder.RegisterType<ChungChiHanhNgheY_TDCMRepository>().As<IChungChiHanhNgheY_TDCMRepository>();
            builder.RegisterType<ChungChiHanhNgheY_QTTHRepository>().As<IChungChiHanhNgheY_QTTHRepository>();
            builder.RegisterType<ChungChiHanhNgheY_CapLaiRepository>().As<IChungChiHanhNgheY_CapLaiRepository>();
            builder.RegisterType<ChungChiHanhNgheY_CapLaiCTRepository>().As<IChungChiHanhNgheY_CapLaiCTRepository>();
            builder.RegisterType<ChungChiHanhNgheY_DieuChinhRepository>().As<IChungChiHanhNgheY_DieuChinhRepository>();
            builder.RegisterType<ChungChiHanhNgheY_DieuChinhCTRepository>().As<IChungChiHanhNgheY_DieuChinhCTRepository>();
            builder.RegisterType<ChungChiHanhNgheY_ThuHoiRepository>().As<IChungChiHanhNgheY_ThuHoiRepository>();
            builder.RegisterType<ChungChiHanhNgheY_RutChungChiRepository>().As<IChungChiHanhNgheY_RutChungChiRepository>();
            builder.RegisterType<DangKyQCTrangThietBiRepository>().As<IDangKyQCTrangThietBiRepository>();
            builder.RegisterType<GiayPhepHoatDongKCBRepository>().As<IGiayPhepHoatDongKCBRepository>();
            builder.RegisterType<GiayPhepHoatDongKCB_DSNhanSuRepository>().As<IGiayPhepHoatDongKCB_DSNhanSuRepository>();
            builder.RegisterType<GiayPhepHoatDongKCB_CapLaiRepository>().As<IGiayPhepHoatDongKCB_CapLaiRepository>();
            builder.RegisterType<GiayPhepHoatDongKCB_CapLaiCTRepository>().As<IGiayPhepHoatDongKCB_CapLaiCTRepository>();
            builder.RegisterType<GiayChungNhanLuongYRepository>().As<IGiayChungNhanLuongYRepository>();
            builder.RegisterType<GiayChungNhanLuongY_QTHanhNgheRepository>().As<IGiayChungNhanLuongY_QTHanhNgheRepository>();
            builder.RegisterType<DM_LinhVucRepository>().As<IDM_LinhVucRepository>();
            builder.RegisterType<DM_NoiCapChungChiRepository>().As<IDM_NoiCapChungChiRepository>();
            builder.RegisterType<DM_PhamViHoatDongChuyenMonRepository>().As<IDM_PhamViHoatDongChuyenMonRepository>();
            builder.RegisterType<DM_TinhThanhRepository>().As<IDM_TinhThanhRepository>();
            builder.RegisterType<DM_QuanHuyenRepository>().As<IDM_QuanHuyenRepository>();
            builder.RegisterType<DM_PhuongXaRepository>().As<IDM_PhuongXaRepository>();
            builder.RegisterType<DM_DuDieuKienHanhNgheRepository>().As<IDM_DuDieuKienHanhNgheRepository>();
            builder.RegisterType<DM_TrinhDoChuyenMonRepository>().As<IDM_TrinhDoChuyenMonRepository>();
            builder.RegisterType<DM_ThuTucRepository>().As<IDM_ThuTucRepository>();
            builder.RegisterType<DM_QuyTrinh_BuocRepository>().As<IDM_QuyTrinh_BuocRepository>();
            builder.RegisterType<DM_QuyTrinh_Buoc_NguoiNhanRepository>().As<IDM_QuyTrinh_Buoc_NguoiNhanRepository>();
            builder.RegisterType<DK_HoiThaoGioiThieuThuoc_DMThuocRepository>().As<IDK_HoiThaoGioiThieuThuoc_DMThuocRepository>();
            builder.RegisterType<DK_HoiThaoGioiThieuThuocRepository>().As<IDK_HoiThaoGioiThieuThuocRepository>();
            builder.RegisterType<CN_GDPRepository>().As<ICN_GDPRepository>();
            builder.RegisterType<CN_GDP_DSKhoRepository>().As<ICN_GDP_DSKhoRepository>();
            builder.RegisterType<CN_GPPRepository>().As<ICN_GPPRepository>();
            builder.RegisterType<CV_XNKThuoc_PhiMauDichRepository>().As<ICV_XNKThuoc_PhiMauDichRepository>();
            builder.RegisterType<CV_XNKThuoc_PhiMauDich_DSThuocRepository>().As<ICV_XNKThuoc_PhiMauDich_DSThuocRepository>();
            builder.RegisterType<TD_KeHoachDauThauRepository>().As<ITD_KeHoachDauThauRepository>();
            builder.RegisterType<TD_KeHoachDauThau_DSGoiThauRepository>().As<ITD_KeHoachDauThau_DSGoiThauRepository>();
            builder.RegisterType<PD_Thuoc_GN_HTT_DSThuocRepository>().As<IPD_Thuoc_GN_HTT_DSThuocRepository>();        
            builder.RegisterType<PD_Thuoc_Methadone_TinhHinhRepository>().As<IPD_Thuoc_Methadone_TinhHinhRepository>();
            builder.RegisterType<PD_Thuoc_GN_HTTRepository>().As<IPD_Thuoc_GN_HTTRepository>();
            builder.RegisterType<CP_Thuoc_VienTroRepository>().As<ICP_Thuoc_VienTroRepository>();
            builder.RegisterType<CP_Thuoc_VienTro_DMThuocRepository>().As<ICP_Thuoc_VienTro_DMThuocRepository>();
            builder.RegisterType<XN_NoiDungQuangCao_SanPhamRepository>().As<IXN_NoiDungQuangCao_SanPhamRepository>();
            builder.RegisterType<XN_NoiDungQuangCaoRepository>().As<IXN_NoiDungQuangCaoRepository>();
            builder.RegisterType<P_CongBoMyPham_ThanhPhanRepository>().As<IP_CongBoMyPham_ThanhPhanRepository>();
            builder.RegisterType<P_CongBoMyPhamRepository>().As<IP_CongBoMyPhamRepository>();
            builder.RegisterType<CN_LuuHanhMyPham_SanPhamRepository>().As<ICN_LuuHanhMyPham_SanPhamRepository>();
            builder.RegisterType<CN_LuuHanhMyPhamRepository>().As<ICN_LuuHanhMyPhamRepository>();
            builder.RegisterType<LichSuBienDongRepository>().As<ILichSuBienDongRepository>();
            builder.RegisterType<GiayChungNhanATSH_DSThietBiRepository>().As<IGiayChungNhanATSH_DSThietBiRepository>();
            builder.RegisterType<GiayChungNhanATSH_DSNhanSuRepository>().As<IGiayChungNhanATSH_DSNhanSuRepository>();
            builder.RegisterType<GiayChungNhanATSH_CapLaiRepository>().As<IGiayChungNhanATSH_CapLaiRepository>();
            builder.RegisterType<GiayChungNhanATSH_CapLaiCTRepository>().As<IGiayChungNhanATSH_CapLaiCTRepository>();
            builder.RegisterType<GiayChungNhanBTGT_CapLaiCTRepository>().As<IGiayChungNhanBTGT_CapLaiCTRepository>();
            builder.RegisterType<GiayChungNhanBTGT_CapLaiRepository>().As<IGiayChungNhanBTGT_CapLaiRepository>();
            builder.RegisterType<GiayChungNhanBTGT_ThanhPhanRepository>().As<IGiayChungNhanBTGT_ThanhPhanRepository>();
            builder.RegisterType<GiayChungNhanBTGTRepository>().As<IGiayChungNhanBTGTRepository>();
            builder.RegisterType<GiayPhepDoanKCB_ThanhVienRepository>().As<IGiayPhepDoanKCB_ThanhVienRepository>();
            builder.RegisterType<GiayPhepDoanKCBRepository>().As<IGiayPhepDoanKCBRepository>();
            builder.RegisterType<GiayPhepHoatDongChuThapDo_CapLaiCTRepository>().As<IGiayPhepHoatDongChuThapDo_CapLaiCTRepository>();
            builder.RegisterType<GiayPhepHoatDongChuThapDo_CapLaiRepository>().As<IGiayPhepHoatDongChuThapDo_CapLaiRepository>();
            builder.RegisterType<GiayPhepHoatDongChuThapDoRepository>().As<IGiayPhepHoatDongChuThapDoRepository>();
            builder.RegisterType<GiayChungNhanATSHRepository>().As<IGiayChungNhanATSHRepository>();
            builder.RegisterType<DM_ChungTuKemTheoRepository>().As<IDM_ChungTuKemTheoRepository>();
            builder.RegisterType<ChungTuKemTheoRepository>().As<IChungTuKemTheoRepository>();
            builder.RegisterType<E_TrangThaiHoSoRepository>().As<IE_TrangThaiHoSoRepository>();
            builder.RegisterType<DM_HinhThucToChucRepository>().As<IDM_HinhThucToChucRepository>();
            builder.RegisterType<E_NoiNhanKetQuaRepository>().As<IE_NoiNhanKetQuaRepository>();
            builder.RegisterType<DM_PhongBanRepository>().As<IDM_PhongBanRepository>();
            builder.RegisterType<PD_Thuoc_MethadoneRepository>().As<IPD_Thuoc_MethadoneRepository>();
            builder.RegisterType<DM_PhamViKinhDoanhRepository>().As<IDM_PhamViKinhDoanhRepository>();
            builder.RegisterType<E_LoaiCapPhepRepository>().As<IE_LoaiCapPhepRepository>();
            builder.RegisterType<CC_DuocRepository>().As<ICC_DuocRepository>();
            builder.RegisterType<CC_Duoc_TDCMRepository>().As<ICC_Duoc_TDCMRepository>();
            builder.RegisterType<CC_Duoc_QTTHRepository>().As<ICC_Duoc_QTTHRepository>();
            builder.RegisterType<CC_Duoc_CapLaiRepository>().As<ICC_Duoc_CapLaiRepository>();
            builder.RegisterType<CC_Duoc_CapLaiCTRepository>().As<ICC_Duoc_CapLaiCTRepository>();
            builder.RegisterType<DM_GoiYRepository>().As<IDM_GoiYRepository>();
            builder.RegisterType<DM_LyDoRepository>().As<IDM_LyDoRepository>();
            builder.RegisterType<E_LoaiLyDoRepository>().As<IE_LoaiLyDoRepository>();
            builder.RegisterType<E_LoaiGoiYRepository>().As<IE_LoaiGoiYRepository>();
            // build container
            return builder.Build();
        }
    }
}